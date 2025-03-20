using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class Topic
    {
        [Key]
        public int TopicID { get; set; }

        [Required]
        public string TopicName { get; set; } = string.Empty;

        // Relationship: One Topic has many SubTopics
        public ICollection<SubTopic> SubTopics { get; set; } = new List<SubTopic>();
    }
}
