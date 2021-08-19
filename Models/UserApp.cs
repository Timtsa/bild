
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ExersiseSQLite.Models
{
    public class UserApp : IdentityUser
    {
        public string DisplayName { get; set; }

        public ICollection<ExersiseModel> ModelsExersise { get; set; }
        public ICollection<ExersiseName> Names { get; set; }

        public UserApp()
        {
            ModelsExersise = new List<ExersiseModel>();
            Names = new List<ExersiseName>();

        }
    }
}
