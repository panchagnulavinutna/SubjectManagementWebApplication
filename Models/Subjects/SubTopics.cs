using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class SubTopics
    {
        [Key]
        public int SubTopicID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        [Required]
        [StringLength(255)]
        public string SubTopicName { get; set; }

        // Navigation property
        public Topics Topic { get; set; }
    }
}
