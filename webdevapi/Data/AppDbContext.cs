﻿using Microsoft.EntityFrameworkCore;
using webdevapi.Models;

namespace webdevapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
