using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Data
{
    public class SubjectManagementWebApplicationContext : DbContext
    {
        public SubjectManagementWebApplicationContext (DbContextOptions<SubjectManagementWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SubjectManagementWebApplication.Models.Subjects.Topics> Topics { get; set; } = default!;
        public DbSet<SubjectManagementWebApplication.Models.Subjects.SubTopics> SubTopics { get; set; } = default!;
    }
}
