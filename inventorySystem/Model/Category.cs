using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class Category
    {
        [Key] public string CategoryID { get; set; } = string.Empty;

        [Required] public string CategoryName { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
