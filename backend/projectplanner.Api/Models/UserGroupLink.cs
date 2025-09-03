using System.ComponentModel.DataAnnotations;


namespace projectplanner.Models
{
    public class UserGroupLink
    {
        [Key]
        public long LinkID { get; set; } // Primary key
        public long UserId { get; set; }
        public long GroupId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsOrganiser { get; set; }
    }
}
