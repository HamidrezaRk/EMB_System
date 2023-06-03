using DataLayer.Entity;
using emb_project.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options) : base(options)
        {

        }

        //

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advertis> Advertises { get; set; }
        // public DbSet<Poll> Poll { get; set; }
    }
}
