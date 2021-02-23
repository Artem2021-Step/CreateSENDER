using EFCreateSeeder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCreateSeeder.DAL.Services
{
    public static class DBSeeder
    {
        public static void SeedAll(EFContext context) 
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedUserRoles(context);
        }
        private static void SeedRoles(EFContext context) 
        {
            if (context.AspNetRoles.Count() == 0) 
            {
                context.AspNetRoles.AddRange(new List<AspNetRole> { 
                new AspNetRole
                {
                    Name = "Doctor",
                    NormalizedName = "Doctor Cardiolog",
                    ConcurrencyStamp = ""
                },
                new AspNetRole
                {
                    Name = "Teacher",
                    NormalizedName = "Web-Design Teacher",
                    ConcurrencyStamp = ""
                },
                new AspNetRole
                {
                    Name = "Manager",
                    NormalizedName = "Manger for Sales",
                    ConcurrencyStamp = ""
                }
                });

                context.SaveChanges();
            }
        }
        private static void SeedUsers(EFContext context) 
        {
            if (context.AspNetUsers.Count() == 0) 
            {
                context.AspNetUsers.AddRange(new List<AspNetUser> {
                new AspNetUser
                {
                    UserName = "Nazar",
                    TwoFactorEnabled = true,
                    AccessFailedCount = "0",
                    ConcurrencyStamp = "",
                    EmailConfirmed = true,
                    Email = "loh.govno.sobaka@lashara.com",
                    LockoutEnabled = true,
                    LockoutEnd =  DateTime.Now,
                    NormalizedEmail = "loh.govno.sobaka@lashara.com",
                    NormalizedUserName ="Nazar Politaew",
                    PasswordHash = "333222111",
                    PhoneNumber = "069696969696969696969",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = ""
                }
                });

                context.SaveChanges();
            }
        }
        private static void SeedUserRoles(EFContext context) 
        {
            if (context.UserRoles.Count() == 0) 
            {
                context.AddRange(new List<AspNetUserRoles> { 
                new AspNetUserRoles 
                {
                    UserId = 1,
                    RoleId = 1,
                }
                });
                context.SaveChanges();
            }
        }

    }
}
