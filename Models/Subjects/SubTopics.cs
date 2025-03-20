using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class SubTopic
    {
        [Key]
        public int SubTopicID { get; set; }

        [Required]
        public string SubTopicName { get; set; } = string.Empty;

        // Foreign Key for Topic
        [ForeignKey("Topic")]
        public int TopicID { get; set; }
        public Topic Topic { get; set; } = null!;
    }
}
