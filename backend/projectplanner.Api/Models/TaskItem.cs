using System.ComponentModel.DataAnnotations;

namespace projectplanner.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskID { get; set; } // Primary key
        public int? ParentID { get; set; }
        public int ProjectID { get; set; }
        public int? AssignedToID { get; set; }
        public string TaskTitle { get; set; } = "";
        public string? TaskDescription { get; set; }
        public bool IsDefaultExpanded { get; set; }
        public int CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public int LastEditedID { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? CompletedByID { get; set; }
        public DateTime LastEditedDate { get; set; }
    }
}
