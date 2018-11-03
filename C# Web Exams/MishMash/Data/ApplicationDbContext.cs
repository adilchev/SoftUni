using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MishMashExam.Models;
using MishMashWebApp.Models;

namespace MishMashExam.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<UserInChannel> UserInChannel { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ChannelTag> ChannelTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MishMash;Integrated Security=True;");
        }
    }
}
