using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class UserProjectLink
    {
        [Key]
        public int LinkID { get; set; } // Primary key
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsOrganiser { get; set; }
    }
}
