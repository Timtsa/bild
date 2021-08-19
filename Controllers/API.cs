using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExersiseSQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ExersiseSQLite.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class API : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<UserApp> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _userId;





        public API(DataContext context, UserManager<UserApp> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
          
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            Console.WriteLine("Constract");

        }

        [HttpGet]
        public async Task<ActionResult<List<ExersiseModel>>> GetExersise()
        {
            Console.WriteLine("ok");
            

            var ex= await _context.Exersises.ToListAsync();
            return ex.FindAll(x => x.UserAppId == GetUserId());
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<ExersiseModel>> GetExersie(int id)
        {
            return await _context.Exersises.FindAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> EditExersise(int id, [FromBody] ExersiseModel exersiseModel)
        {
            var exersise = await _context.Exersises.FindAsync(id);
            if (exersise == null)
                throw new Exception("Cold not find exersise");
            exersise.Date = exersiseModel.Date ?? exersise.Date;
            exersise.Exersise = exersiseModel.Exersise ?? exersise.Exersise;
            exersise.FirstApproach = exersiseModel.FirstApproach ?? exersise.FirstApproach;
            exersise.SecondApproach = exersiseModel.SecondApproach ?? exersise.SecondApproach;
            exersise.ThirdtApproach = exersiseModel.ThirdtApproach ?? exersise.ThirdtApproach;
            exersise.FourthtApproach = exersiseModel.FourthtApproach ?? exersise.FourthtApproach;
            exersise.FirstWeight = exersiseModel.FirstWeight ?? exersise.FirstWeight;
            exersise.SecondWeight = exersiseModel.SecondWeight ?? exersise.SecondWeight;
            exersise.Thirdtweight = exersiseModel.Thirdtweight ?? exersise.Thirdtweight;
            exersise.Fourthtweight = exersiseModel.Fourthtweight ?? exersise.Fourthtweight;
            

            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");
        }

        [HttpPost]
        public async Task<bool> Createexersise([FromBody] ExersiseModel exersiseModel)
        {
            var exersise = new ExersiseModel
            {
                Date = exersiseModel.Date,
                Exersise = exersiseModel.Exersise,
                FirstApproach = exersiseModel.FirstApproach,
                SecondApproach = exersiseModel.SecondApproach,
                ThirdtApproach = exersiseModel.ThirdtApproach,
                FourthtApproach = exersiseModel.FourthtApproach,
                FirstWeight = exersiseModel.FirstWeight,
                SecondWeight = exersiseModel.SecondWeight,
                Thirdtweight = exersiseModel.Thirdtweight,
                Fourthtweight = exersiseModel.Fourthtweight,
                UserAppId = GetUserId()
                
            };

            _context.Exersises.Add(exersise);
            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");

        }



        [HttpDelete("{id}")]
        public async Task<bool> DeleteExersise(int id)
        {
            var _exersise = await _context.Exersises.FindAsync(id);
            if(_exersise==null)
                throw new Exception("Could not find exersise");
            _context.Remove(_exersise);
            var sucses = await _context.SaveChangesAsync() > 0;
            if (sucses)
                return sucses;
            throw new Exception("Problem saving changes");
        }

        [Route("names")]
        public async Task<ActionResult<List<ExersiseName>>> GetName()
        {
            var ex = await _context.ExersiseNames.ToListAsync();
            return ex.FindAll(x => x.UserAppId == GetUserId());
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

