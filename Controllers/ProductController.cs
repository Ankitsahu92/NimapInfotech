using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NimapInfotech.Entity;

namespace NimapInfotech.Controllers
{
    public class ProductController : Controller
    {
        private readonly NimapInfotechContext dbContext;
        public ProductController(NimapInfotechContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var data = await this.dbContext.ProductMaster.Include(c => c.CategoryMaster).ToListAsync();
            return View();
        }
    }
}
