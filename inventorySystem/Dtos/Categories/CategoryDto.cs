namespace inventorySystem.Dtos.Categories
{
    public class CategoryDto
    {
        public string CategoryID { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
    }

    public class CreateCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
    }

    public class UpdateCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
