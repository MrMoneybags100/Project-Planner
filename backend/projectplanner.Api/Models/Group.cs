using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class Group
    {
        [Key]
        public long GroupID { get; set; } // Primary key
        public string GroupTitle { get; set; } = "";
    }
}
