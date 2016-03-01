namespace WebApi.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Infrastructure;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Infrastructure.ApplicationDbContext context)
        {
            //  Este metodo va a ser llamado despues de haber migrado a la ultima version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "rex2002xp",
                Email = "rex2002xp@gmail.com",
                EmailConfirmed = true,
                FirstName = "Victor",
                LastName = "Cornejo",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "MySuperP@ssword!");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new ApplicationRole { Name = "SuperAdmin", Description = "Usuarios con el nivel mas alto de acceso." });
                roleManager.Create(new ApplicationRole { Name = "Admin", Description = "Usuarios administradores." });
                roleManager.Create(new ApplicationRole { Name = "User", Description = "Usuario con acceso minimo" });
            }

            var adminUser = manager.FindByName("rex2002xp");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
