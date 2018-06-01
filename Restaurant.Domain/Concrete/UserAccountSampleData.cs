using Microsoft.AspNet.Identity.EntityFramework;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete
{
    public class UserAccountSampleData : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private string Hash(string password)
        {
            int saltSize = 16;
            int bytesRequired = 32;
            byte[] array = new byte[1 + saltSize + bytesRequired];
            int iterations = 1000; // 1000, afaik, which is the min recommended for Rfc2898DeriveBytes
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltSize, iterations))
            {
                byte[] salt = pbkdf2.Salt;
                Buffer.BlockCopy(salt, 0, array, 1, saltSize);
                byte[] bytes = pbkdf2.GetBytes(bytesRequired);
                Buffer.BlockCopy(bytes, 0, array, saltSize + 1, bytesRequired);
            }
            return Convert.ToBase64String(array);
        }

        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationRole employeeRole = new ApplicationRole("Employee", DateTime.Now);
            ApplicationRole adminRole = new ApplicationRole("Admin", DateTime.Now);

            ApplicationUser user = new ApplicationUser
            {
                UserName = "testUser@fake.com",
                Email = "testUser@fake.com",
                PasswordHash = Hash("12345"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                AccountRegisterDate = DateTime.Now
            };
            IdentityUserRole userOfRole = new IdentityUserRole
            {
                RoleId = employeeRole.Id,
                UserId = user.Id
            };

            ApplicationUser admin = new ApplicationUser
            {
                UserName = "admin@fake.com",
                Email = "admin@fake.com",
                PasswordHash = Hash("12345"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                AccountRegisterDate = DateTime.Now
            };
            IdentityUserRole adminOfRole = new IdentityUserRole
            {
                RoleId = adminRole.Id,
                UserId = admin.Id
            };

            user.Roles.Add(userOfRole);
            admin.Roles.Add(adminOfRole);

            context.Roles.Add(employeeRole);
            context.Roles.Add(adminRole);

            context.Users.Add(user);
            context.Users.Add(admin);

            base.Seed(context);
        }
    }
}
