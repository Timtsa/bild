
using Microsoft.EntityFrameworkCore;

namespace ExersiseSQLite.Models
{
   
    public class ExersiseName
    {
        public int Id { get; set; }
        public string Exersise { get; set; }
        public UserApp UserApp { get; set; }

        public string UserAppId { get; set; }
    }
}