using HugDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HugDb
{
    public class HugDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hug> Hugs { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<UserCommittee> UserCommittees { get; set; }
        public DbSet<ShopItemType> ShopItemTypes { get; set; }

        public HugDbContext(DbContextOptions<HugDbContext> options) : base(options)
        {
             
        }
        //primary keys galim nustatyti, auto id galim isjungti, sprendzia musu n su problema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hug>().HasOne<User>(x => x.FromUser);
            modelBuilder.Entity<Hug>().HasOne<User>(x => x.ToUser);
            modelBuilder.Entity<User>().HasMany(x => x.Hugs).WithOne();
            base.OnModelCreating(modelBuilder);
        }
    }
}
