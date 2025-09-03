using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; } // Primary key
        public string UserName { get; set; } = "";
    }
}
