using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectManagementWebApplication.Models.Subjects
{
    public class Topics
    {
        [Key]
        public int TopicID { get; set; }

        [Required]
        [StringLength(255)]
        public string TopicName { get; set; }

        // Navigation property for related SubTopics
        public ICollection<SubTopics> SubTopics { get; set; } = new List<SubTopics>();
    }
}
