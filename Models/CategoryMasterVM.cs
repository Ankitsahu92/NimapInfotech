using System.ComponentModel.DataAnnotations;

namespace NimapInfotech.Models
{
    public class CategoryMasterVM : BaseClassVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
