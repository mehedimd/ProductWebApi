﻿using Microsoft.EntityFrameworkCore;

namespace ProductWebApi.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; } 
    }
}
