using System;
using jobsity_chat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace jobsity_chat.Context
{
    public class DBChatContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DBChatContext(DbContextOptions<DBChatContext> options)
     : base(options) { }

        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
