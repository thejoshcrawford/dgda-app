using System.ComponentModel.DataAnnotations;

namespace DgdaBackend.Entities
{
    public class Product
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool InStock { get; set; }
    }
}
