using EFCreateSeeder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCreateSeeder.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRoles> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=allah;Username=gomonmax;Password=578947001;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetUserRoles>(data =>
            {
                data.HasKey(primaryKeys => new { primaryKeys.RoleId, primaryKeys.UserId });

                data.HasOne(userRolesVirtualColumnFromRole => userRolesVirtualColumnFromRole.Role)
                .WithMany(userRolesVirtualCollectionFromUserRoles => userRolesVirtualCollectionFromUserRoles.UserRoles)
                .HasForeignKey(userRolesIntColumnFromRoleWithForeignSettings => 
                userRolesIntColumnFromRoleWithForeignSettings.RoleId)
                .IsRequired();
                data.HasOne(userRolesVirtualColumnFromUser => userRolesVirtualColumnFromUser.User)
                .WithMany(userRolesVirtualCollectionFromUserRoles => userRolesVirtualCollectionFromUserRoles.UserRoles)
                .HasForeignKey(userRolesIntColumnWithForeignSettings => userRolesIntColumnWithForeignSettings.UserId)
                .IsRequired();
                
            });
        }
    }
}
