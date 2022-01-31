using Microsoft.AspNetCore.Mvc.Rendering;
using NimapInfotech.Models.EntityModels;

namespace NimapInfotech.Models
{
    public class AddProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem>? CategoryMasterList { get; set; }

    }
}
