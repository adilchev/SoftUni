using System;
using System.Collections.Generic;
using System.Text;
using ExamWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Chushka;Integrated Security=True;");
        }
    }
}
