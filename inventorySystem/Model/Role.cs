using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class Role
    {
        [Key] public string RoleID { get; set; } = string.Empty;

        [Required] public string RoleName { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
