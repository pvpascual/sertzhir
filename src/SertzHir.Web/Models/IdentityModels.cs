﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SertzHir.Core.Entities;
using SertzHir.Core.Interfaces;

namespace SearchzHir.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       
    }

    public class SertzHirAdminDbContext : IdentityDbContext<ApplicationUser>
    {
        public SertzHirAdminDbContext()
            : base("SertzHirAdminContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SertzHirAdminDbContext, SearchzHir.Web.Migrations.Configuration>());
        }

        public static SertzHirAdminDbContext Create()
        {
            return new SertzHirAdminDbContext();
        }

    }
}