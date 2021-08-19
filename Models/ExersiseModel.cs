using System;
using Microsoft.EntityFrameworkCore;

namespace ExersiseSQLite.Models
{

    public class ExersiseModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Exersise { get; set; }

        public int? FirstApproach { get; set; }
        public int? SecondApproach { get; set; }
        public int? ThirdtApproach { get; set; }
        public int? FourthtApproach { get; set; }

        public int? FirstWeight { get; set; }
        public int? SecondWeight { get; set; }
        public int? Thirdtweight { get; set; }
        public int? Fourthtweight { get; set; }

        public UserApp UserApp { get; set; }

        public string UserAppId { get; set; }

    }
}