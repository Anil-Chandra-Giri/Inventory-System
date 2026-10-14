namespace inventorySystem.Dtos.Roles
{
    public class RoleDto
    {
        public string RoleID { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public int UserCount { get; set; }
    }

    public class CreateRoleDto
    {
        public string RoleName { get; set; } = string.Empty;
    }
}
