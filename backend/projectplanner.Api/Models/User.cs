using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; } // Primary key
        public string UserName { get; set; } = "";
        public string? UserEmail { get; set; } = "";
    }
}
