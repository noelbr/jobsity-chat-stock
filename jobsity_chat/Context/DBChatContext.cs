using System;
using jobsity_chat.Models;
using Microsoft.EntityFrameworkCore;
namespace jobsity_chat.Context
{
    public class DBChatContext : DbContext
    {
        public DBChatContext(DbContextOptions<DBChatContext> options)
     : base(options) { }

        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
