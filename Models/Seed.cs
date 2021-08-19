
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ExersiseSQLite.Models
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<UserApp> user)
        {
            if (!user.Users.Any())
            {
                var users = new List<UserApp>
                {
                new UserApp{DisplayName="Sam", UserName="sam", Email="sam@test.com",
                  Names = new List<ExersiseName>
                {
                 new ExersiseName{
                     Id=1,
                   Exersise="Жим лежа"
                 },
                 new ExersiseName{
                     Id=2,
                   Exersise="Брусья"
                 },
                 new ExersiseName{
                     Id=3,
                   Exersise="Молоточки"
                 }

                },
                  ModelsExersise = new List<ExersiseModel>
                {
                  new ExersiseModel{
                      Id=4,
                      Date =DateTime.Now,
                      Exersise="Молоточки",
                      FirstApproach= 8,
                      SecondApproach=8,
                      ThirdtApproach=8,
                      FourthtApproach=8,
                      FirstWeight =20,
                      SecondWeight =20,
                      Thirdtweight =20,
                      Fourthtweight =20    },

                       new ExersiseModel{
                      Id=5,
                      Date =DateTime.Now,
                      Exersise="Жим лежа",
                      FirstApproach= 8,
                      SecondApproach=8,
                      ThirdtApproach=8,
                      FourthtApproach=8,
                      FirstWeight =15,
                      SecondWeight =15,
                      Thirdtweight =15,
                      Fourthtweight =15    }

                }



            },
                new UserApp{DisplayName="Bob", UserName="bob", Email="bob@test.com",
                 Names = new List<ExersiseName>
                {
                 new ExersiseName{
                     Id=4,
                   Exersise="Жим лежа"
                 },
                 new ExersiseName{
                     Id=5,
                   Exersise="Брусья"
                 },
                 new ExersiseName{
                     Id=6,
                   Exersise="Молоточки"
                 }

                },
                  ModelsExersise = new List<ExersiseModel>
                {
                  new ExersiseModel{
                      Id=6,
                      Date =DateTime.Now,
                      Exersise="Молоточки",
                      FirstApproach= 8,
                      SecondApproach=8,
                      ThirdtApproach=8,
                      FourthtApproach=8,
                      FirstWeight =10,
                      SecondWeight =10,
                      Thirdtweight =10,
                      Fourthtweight =10    },

                       new ExersiseModel{
                      Id=7,
                      Date =DateTime.Now,
                      Exersise="Жим лежа",
                      FirstApproach= 8,
                      SecondApproach=8,
                      ThirdtApproach=8,
                      FourthtApproach=8,
                      FirstWeight =10,
                      SecondWeight =10,
                      Thirdtweight =10,
                      Fourthtweight =10    }

                }

            }
                };

                foreach (var us in users)
                {
                    await user.CreateAsync(us, "Pa$$word2");
                }
            }



            //if (!context.ExersiseNames.Any())
            //{
            //    var exersiseNames = new List<ExersiseName>
            //    {
            //     new ExersiseName{
            //         Id=1,
            //       Exersise="Жим лежа"
            //     },
            //     new ExersiseName{
            //         Id=2,
            //       Exersise="Брусья"
            //     },
            //     new ExersiseName{
            //         Id=3,
            //       Exersise="Молоточки"
            //     }

            //    };

            //    context.ExersiseNames.AddRange(exersiseNames);
            //    context.SaveChanges();
            //}


            //if (!context.Exersises.Any())
            //{
            //    var exersise = new List<ExersiseModel>
            //    {
            //      new ExersiseModel{
            //          Id=4,
            //          Date =DateTime.Now,
            //          Exersise="Молоточки",
            //          FirstApproach= 8,
            //          SecondApproach=8,
            //          ThirdtApproach=8,
            //          FourthtApproach=8,
            //          FirstWeight =20,
            //          SecondWeight =20,
            //          Thirdtweight =20,
            //          Fourthtweight =20    },

            //           new ExersiseModel{
            //          Id=5,
            //          Date =DateTime.Now,
            //          Exersise="Жим лежа",
            //          FirstApproach= 8,
            //          SecondApproach=8,
            //          ThirdtApproach=8,
            //          FourthtApproach=8,
            //          FirstWeight =20,
            //          SecondWeight =20,
            //          Thirdtweight =20,
            //          Fourthtweight =20    }

            //    };

            //    context.Exersises.AddRange(exersise);
            //    context.SaveChanges();
            //}
        }
    }
}