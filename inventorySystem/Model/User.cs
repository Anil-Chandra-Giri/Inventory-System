using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace inventorySystem.Model
{
    public class User
    {
        [Key] public string UserID { get; set; } = string.Empty;

        [Required] public string UserName { get; set; } = string.Empty;

        [Required] public string PasswordHash { get; set; } = string.Empty;

        [Required] public string RoleID { get; set; } = string.Empty;
        public Role? Role { get; set; }
    }
}
