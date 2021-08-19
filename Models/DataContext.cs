using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExersiseSQLite.Models

{
    public class DataContext : IdentityDbContext<UserApp>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ExersiseModel> Exersises { get; set; }

        public DbSet<ExersiseName> ExersiseNames { get; set; }


    }
}