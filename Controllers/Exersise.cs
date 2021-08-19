using System.Threading.Tasks;
using ExersiseSQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ExersiseSQLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Exersise : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<UserApp> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _userId;
        public Exersise(DataContext context, UserManager<UserApp> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExersiseName>>> GetExersisename()
        {
            var ex = await _context.ExersiseNames.ToListAsync();
            return ex.FindAll(x => x.UserAppId == GetUserId());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExersiseName>> GetExersiseName(int id)
        {
            return await _context.ExersiseNames.FindAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> EditExersise(int id, [FromBody] ExersiseName exersiseName)
        {
            var exersise = await _context.ExersiseNames.FindAsync(id);
            if (exersise == null)
                throw new Exception("Cold not find exersise");
            exersise.Exersise = exersiseName.Exersise ?? exersise.Exersise;
            
            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");
        }

        [HttpPost]
        public async Task<bool> Createexersise([FromBody] ExersiseName exersiseName)
        {
            var exersise = new ExersiseName
            {
                Exersise = exersiseName.Exersise,
                UserAppId = GetUserId()
                
            };

            _context.ExersiseNames.Add(exersise);
            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteExersise(int id)
        {
            var _exersise = await _context.ExersiseNames.FindAsync(id);
            if (_exersise == null)
                throw new Exception("Could not find exersise");
            _context.Remove(_exersise);
            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");
        }

        private string GetUserId()
        {
            if (!String.IsNullOrEmpty(_userId))
                return _userId;

            else
            {
                return _httpContextAccessor.HttpContext.User?.Claims?.
                FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }
        }

    }
}
