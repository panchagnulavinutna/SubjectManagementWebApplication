using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Models.Subjects;

namespace SubjectManagementWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // ✅ Use correct singular model names
        public DbSet<Topic> Topics { get; set; }  // ✅ Corrected from `Topics` → `Topic`
        public DbSet<SubTopic> SubTopics { get; set; }  // ✅ Corrected from `SubTopics` → `SubTopic`

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.SubTopics)
                .WithOne(s => s.Topic)
                .HasForeignKey(s => s.TopicID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
