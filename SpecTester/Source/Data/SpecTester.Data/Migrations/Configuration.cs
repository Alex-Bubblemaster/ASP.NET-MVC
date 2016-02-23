namespace SpecTester.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using SpecTester.Common;

    public sealed class Configuration : DbMigrationsConfiguration<SpecTesterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SpecTesterDbContext context)
        {
            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = GlobalConstants.AdministratorUserName,
                    Email = GlobalConstants.AdministratorUserName
                };
                userManager.Create(user, GlobalConstants.AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (context.TrainingSessions.Any())
            {
                return;
            }

            var passwordHasher = new PasswordHasher();

            var training = new TrainingSession()
            {
                Name = "Basic Training",
                Score = 100,
                Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "English Breakfast",
                            HasSauce = false,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Sausages",
                                    ImageUrl = "sausages.png"
                                },
                                new Product()
                                {
                                    Name = "Bacon",
                                    ImageUrl = "bacon.png"
                                },
                                new Product()
                                {
                                    Name = "Tomatoes",
                                    ImageUrl = "tomato.png"
                                },
                                new Product()
                                {
                                    Name = "Fried egg",
                                    ImageUrl = "friedegg.png"
                                },
                                new Product()
                                {
                                    Name = "Toast",
                                    ImageUrl = "toast.png"
                                },
                                new Product()
                                {
                                    Name = "Black pudding",
                                    ImageUrl = "blackPudding.png"
                                }
                            }
                        }
                        /*,
                        new Dish()
                        {
                            Name = "Pork with egg and pineapple",
                            HasSauce = false,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "French fries",
                                },
                                new Product()
                                {
                                    Name = "Pork chop",
                                },
                                new Product()
                                {
                                    Name = "Eggs" + i,
                                },
                                new Product()
                                {
                                    Name = "Pineapple" + i,
                                },
                                new Product()
                                {
                                    Name = "Peas" + i,
                                }
                            }
                        },
                        new Dish()
                        {
                            Name = "Mix Grill " + i,
                            HasSauce = true,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Steak " + i,
                                },
                                new Product()
                                {
                                    Name = "Pork " + i,
                                },
                                new Product()
                                {
                                    Name = "Sausage " + i,
                                },
                                new Product()
                                {
                                    Name = "Chicken Breast " + i,
                                },
                                new Product()
                                {
                                    Name = "Beef " + i,
                                },
                            }
                        }*/
                    },
                Users = new List<User>()
                    {
                        new User()
                        {
                            UserName = "Chef",
                            Email = "chef@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password")
                        },
                        new User()
                        {
                            UserName = "Grill Master",
                            Email = "grillMaster@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password")
                        },
                        new User()
                        {
                            UserName = "Waitress",
                            Email = "waitress@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password")
                        },
                    },

                Author = context.Users.FirstOrDefault(admin => admin.UserName == GlobalConstants.AdministratorUserName)
            };

            context.TrainingSessions.Add(training);
            context.SaveChanges();
        }
    }
}
