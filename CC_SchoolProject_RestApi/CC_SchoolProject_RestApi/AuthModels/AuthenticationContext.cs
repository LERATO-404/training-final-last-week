using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CC_SchoolProject_RestApi.AuthModels
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            var roleId_1 = Guid.NewGuid().ToString();
            var userId_1 = Guid.NewGuid().ToString();

            var roleId_2 = Guid.NewGuid().ToString();
            var userId_2 = Guid.NewGuid().ToString();

            var roleId_3 = Guid.NewGuid().ToString();
            var userId_3 = Guid.NewGuid().ToString();




            #region "Seed Data"
            builder.Entity<IdentityRole>().HasData(
                new { Id = roleId_1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new { Id = roleId_2, Name = "Teacher", NormalizedName = "TEACHER" },
                new { Id = roleId_3, Name = "Principal", NormalizedName = "PRINCIPAL" }
             );


            //create Administrator user
            var AdminUser = new ApplicationUser
            {
                Id = userId_1,
                Email = "Admin@school.gmail.com",
                EmailConfirmed = true,
                FirstName = "AdminF",
                LastName = "AdminL",
                UserName = "AdminOne",
                NormalizedUserName = "ADMINONE",

            };

            //set user password
            PasswordHasher<ApplicationUser> adminph = new PasswordHasher<ApplicationUser>();
            AdminUser.PasswordHash = adminph.HashPassword(AdminUser, "Admin!1SE5");

            //seed user
            builder.Entity<ApplicationUser>().HasData(AdminUser);


            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId_1,
                UserId = userId_1
            });

            //create Teacher user
            var TeacherUser = new ApplicationUser
            {
                Id = userId_2,
                Email = "Teacher@school.gmail.com",
                EmailConfirmed = true,
                FirstName = "TeacherF",
                LastName = "TeacherL",
                UserName = "TeacherOne",
                NormalizedUserName = "TEACHERONE"
            };

            //set user password
            PasswordHasher<ApplicationUser> managerph = new PasswordHasher<ApplicationUser>();
            TeacherUser.PasswordHash = managerph.HashPassword(TeacherUser, "Teacher$125");

            //seed user
            builder.Entity<ApplicationUser>().HasData(TeacherUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId_2,
                UserId = userId_2
            });

            //create Principal user
            var PrincipalUser = new ApplicationUser
            {
                Id = userId_3,
                Email = "Principal@school.gmail.com",
                EmailConfirmed = true,
                FirstName = "PrincipalF",
                LastName = "PrincipalL",
                UserName = "PrincipalOne",
                NormalizedUserName = "PRINCIPALONE"
            };

            //set user password
            PasswordHasher<ApplicationUser> driverph = new PasswordHasher<ApplicationUser>();
            PrincipalUser.PasswordHash = driverph.HashPassword(PrincipalUser, "Principal$123%");

            //seed user
            builder.Entity<ApplicationUser>().HasData(PrincipalUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId_3,
                UserId = userId_3
            });

            #endregion

        }
    }
}
