using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace inventorySystem.Model
{
    public class User
    {
        [Key] public Guid UserID { get; set; } 
        [Required] public string FullName { get; set; } = string.Empty;

        [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

        [Required] public string UserName { get; set; } = string.Empty;

        [JsonIgnore] public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }

        [Required] public Guid RoleID { get; set; }
        [JsonIgnore] public Role? Role { get; set; }
    }
}
