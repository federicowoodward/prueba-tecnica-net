using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProductos.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; } = new();
    }
}
