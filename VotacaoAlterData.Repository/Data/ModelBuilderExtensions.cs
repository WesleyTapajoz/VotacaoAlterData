using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using VotacaoAlterData.Domain;


namespace VotacaoAlterData.Repository.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var ADMIN_ID = 1;
            var ROLE_ID = ADMIN_ID;

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin"
            });


            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = ADMIN_ID,
                FullName = "Admin",
                UserName = "Admin",
                Email = "admin@teste.com",
                PasswordHash = "AN2Uz2xYRQcCzspOftD/qLVurazVpR/S9Ly9arC4OeX8PweDkNX6F8EFxqPjSgolpg==",
                NormalizedUserName = "admin@teste.com".ToUpper(),
                NormalizedEmail = "admin@teste.com".ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            });




            //modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = ADMIN_ID
            //});
        }
    }
}
