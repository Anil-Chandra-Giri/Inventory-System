using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace inventorySystem.Model
{
    public class User
    {
        [Key] public string UserID { get; set; } = string.Empty;
        [Required] public string FullName { get; set; } = string.Empty;

        [Required] public string Email { get; set; } = string.Empty;

        [Required] public string UserName { get; set; } = string.Empty;

        [Required] [JsonIgnore] public string PasswordHash { get; set; } = string.Empty;

        [Required] public string RoleID { get; set; } = string.Empty;
        [JsonIgnore] public Role? Role { get; set; }
    }
}
