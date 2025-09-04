using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; } // Primary key
        public int CreatedID { get; set; }
        public int LastEditedID { get; set; }
        public string ProjectTitle { get; set; } = "";
        public string? ProjectDescription { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDefaultExpanded { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
