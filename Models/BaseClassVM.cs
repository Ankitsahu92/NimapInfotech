using System.ComponentModel.DataAnnotations;

namespace NimapInfotech.Models
{
    public class BaseClassVM
    {
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedByIP { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByIP { get; set; }
        public bool isActive { get; set; } = true;
    }
}
