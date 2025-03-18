using Microsoft.EntityFrameworkCore;
using SubjectManagementWebApplication.Models.Subjects;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Topics> Topics { get; set; }
    public DbSet<SubTopics> SubTopics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Topics>()
            .HasMany(t => t.SubTopics)
            .WithOne(s => s.Topic)
            .HasForeignKey(s => s.TopicID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
