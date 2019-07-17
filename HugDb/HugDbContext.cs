using HugDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HugDb
{
    public class HugDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hug> Hugs { get; set; }
        public HugDbContext(DbContextOptions<HugDbContext> options) : base(options)
        {
             
        }
    }
}
