namespace SpecTester.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Models.Common;
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

            for (int i = 1; i < 10; i++)
            {
                var training = new TrainingSession()
                {
                    Name = "Training " + (i + 1),
                    Score = 100 + (i * 10),
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "English Breakfast " + i,
                            Plate = PlateShape.Round,
                            HasSauce = i % 2 == 0,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Sausages" + i,
                                    CookingMethods = CookingMethod.DeepFry & CookingMethod.ShallowFry
                                },
                                new Product()
                                {
                                    Name = "Potatoes" + i,
                                    CookingMethods = CookingMethod.DeepFry & CookingMethod.Boil
                                },
                                new Product()
                                {
                                    Name = "Tomatoes" + i,
                                    CookingMethods = CookingMethod.Grill & CookingMethod.ReadyToEat
                                },
                                new Product()
                                {
                                    Name = "Mushrooms" + i,
                                    CookingMethods = CookingMethod.ShallowFry
                                },
                                new Product()
                                {
                                    Name = "Beans" + i,
                                    CookingMethods = CookingMethod.ReadyToEat
                                }
                            }
                        },
                        new Dish()
                        {
                            Name = "Pork with egg and pineapple " + i,
                            Plate = PlateShape.Square,
                            HasSauce = false,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "French fries" + i,
                                    CookingMethods = CookingMethod.DeepFry
                                },
                                new Product()
                                {
                                    Name = "Pork chop" + i,
                                    CookingMethods = CookingMethod.Grill
                                },
                                new Product()
                                {
                                    Name = "Eggs" + i,
                                    CookingMethods = CookingMethod.ShallowFry
                                },
                                new Product()
                                {
                                    Name = "Pineapple" + i,
                                    CookingMethods = CookingMethod.Grill
                                },
                                new Product()
                                {
                                    Name = "Peas" + i,
                                    CookingMethods = CookingMethod.Boil
                                }
                            }
                        },
                        new Dish()
                        {
                            Name = "Mix Grill " + i,
                            Plate = PlateShape.Rectangular,
                            HasSauce = true,
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Steak " + i,
                                CookingMethods = CookingMethod.Grill
                                },
                                new Product()
                                {
                                    Name = "Pork " + i,
                                CookingMethods = CookingMethod.Grill
                                },
                                new Product()
                                {
                                    Name = "Sausage " + i,
                                    CookingMethods = CookingMethod.ShallowFry
                                },
                                new Product()
                                {
                                    Name = "Chicken Breast " + i,
                                    CookingMethods = CookingMethod.Roast
                                },
                                new Product()
                                {
                                    Name = "Beef " + i,
                                    CookingMethods = CookingMethod.ShallowFry
                                },
                            }
                        }
                    },
                    Users = new List<User>()
                    {
                        new User()
                        {
                            UserName = "Chef " + i,
                            Email = "chef" + i + "@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password" + i)
                        },
                        new User()
                        {
                            UserName = "Grill Master " + i,
                            Email = "grillMaster" + i + "@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password" + i)
                        },
                        new User()
                        {
                            UserName = "Waitress " + i,
                            Email = "waitress" + i + "@spectester.com",
                            PasswordHash = passwordHasher.HashPassword("password" + i)
                        },
                    },

                    Author = context.Users.FirstOrDefault(admin => admin.UserName == GlobalConstants.AdministratorUserName)
                };

                context.TrainingSessions.Add(training);
                context.SaveChanges();
            }
        }
    }
}
