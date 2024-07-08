using System;
using Domain.Enums;
using Domain.Models.Chats;
using Domain.Models.Roles;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ProjectContext:DbContext
    {
        #region DbSets
        
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        #endregion
        
        public ProjectContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            #region ConvertEnum

            modelBuilder.Entity<RolePermission>().Property(p => p.Permission)
                .HasConversion(p => p.ToString(), p => (PermissionEnum) Enum.Parse(typeof(PermissionEnum), p));


            #endregion
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
