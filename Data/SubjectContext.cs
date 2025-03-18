using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Data
{
    public class SubjectContext : DbContext
    {
        public SubjectContext (DbContextOptions<SubjectContext> options)
            : base(options)
        {
        }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<SubTopics> SubTopics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topics>().ToTable("Topics");
            modelBuilder.Entity<SubTopics>().ToTable("SubTopics");
        }
    }
}
