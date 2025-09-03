using System.ComponentModel.DataAnnotations;

namespace projectplanner.Models
{
    public class TaskItem
    {
        [Key]
        public long TaskID { get; set; } // Primary key
        public long GroupID { get; set; }
        public long CreatedID { get; set; }
        public long LastEditedID { get; set; }
        public string TaskTitle { get; set; } = ""; // Mandatory
        public string? TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsExpanded { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
