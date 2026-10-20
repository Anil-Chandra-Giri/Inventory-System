using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class Role
    {
        [Key] public string RoleID { get; set; } = string.Empty;

        [Required] public string RoleName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
