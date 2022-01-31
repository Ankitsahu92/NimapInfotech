using NimapInfotech.Models.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapInfotech.Models
{
    public class ProductMasterVM : BaseClassVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [ForeignKey("CategoryMaster")]
        [Required]
        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryMasterName { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }
    }
}
