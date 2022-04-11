using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RojgarMantra.Controllers;
using RojgarMantra.Data;
using RojgarMantra.Data.Entities;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace RojgarMantra
{
    public static class Seed
    {
        public static void Data(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("johndoe@localhost.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "johndoe@localhost.com";
                user.Email = "johndoe@localhost.com";
                user.FirstName = "John";
                user.LastName = "Doe";
                //user.MarriedStatus = "Married";

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user.Id, "User").Wait();
                }
            }


            if (userManager.FindByEmailAsync("alex@localhost.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "alex@localhost.com";
                user.Email = "alex@localhost.com";
                user.FirstName = "Alex";
                user.LastName = "Calingasan";
                //user.MarriedStatus = "Unmarried";
                //user.FirstName = "Alex";
                //user.LastName = "Cargo";
                //user.Gender = "Male";
                //user.DateOfBirth = new System.DateTime(1978, 4, 23);
                //user.AlternateContactNumber = "4848374855";
                //user.Country = "Jamaica";
                //user.State = "Arkansas";
                //user.City = "Taimur";
                //user.PermanentLocation = "Balti";
                //user.PrefferredLocation = "More";

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user.Id, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
          /*  if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }*/


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("TrainingInstitute").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "TrainingInstitute";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employer").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Employer";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("JobSeeker").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "JobSeeker";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
