using System;
using System.Collections.Generic;
using System.Text;
using ChushkaExam.Models;
using Microsoft.EntityFrameworkCore;

namespace ChushkaExam.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SASHO\\SQLEXPRESS;Database=Chushka;Integrated Security=True;");
        }
    }
}
