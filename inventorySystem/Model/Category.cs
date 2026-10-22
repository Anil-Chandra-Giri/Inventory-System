using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class Category
    {
        [Key] public Guid CategoryID {  get; set; }
        public string CategoryCode { get; set; } = string.Empty;

        [Required] public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
