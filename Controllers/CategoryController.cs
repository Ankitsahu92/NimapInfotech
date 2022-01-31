using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NimapInfotech.Entity;
using NimapInfotech.Models;
using NimapInfotech.Models.EntityModels;

namespace NimapInfotech.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NimapInfotechContext dbContext;
        public CategoryController(NimapInfotechContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategory model)
        {
            return PartialView("_AddCategory", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAddCategory(AddCategory model)
        {
            bool isSuccess = false;
            if (model.Id > 0)
            {
                var data = await this.dbContext.CategoryMaster.FirstOrDefaultAsync(f => f.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.ModifiedBy = "yashi";
                    data.ModifiedOn = DateTime.Now;
                    this.dbContext.CategoryMaster.Update(data);
                }
            }
            else
            {
                var obj = new CategoryMaster()
                {
                    Name = model.Name,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "yashi"
                };
                await this.dbContext.CategoryMaster.AddAsync(obj); ;
            }

            int record = await this.dbContext.SaveChangesAsync();
            isSuccess = record > 0;

            return Json(new { success = isSuccess, model });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool isSuccess = false;
            if (id > 0)
            {
                var data = await this.dbContext.CategoryMaster.FirstOrDefaultAsync(f => f.Id == id);
                if (data != null)
                {
                    data.isActive = false;
                    data.ModifiedBy = "yashi";
                    data.ModifiedOn = DateTime.Now;
                    this.dbContext.CategoryMaster.Update(data);
                }
            }

            int record = await this.dbContext.SaveChangesAsync();
            isSuccess = record > 0;

            return Json(new { success = isSuccess });
        }

        [HttpPost]
        public async Task<IActionResult> LoadCategoryMaster()
        {
            try
            {
                List<CategoryMaster> data = new List<CategoryMaster>();
                string draw, start, length, sortColumn, sortColumnDir, search, col1;
                draw = Request.Form.FirstOrDefault(x => x.Key == "draw").Value.FirstOrDefault();
                start = Request.Form.FirstOrDefault(x => x.Key == "start").Value.FirstOrDefault();
                length = Request.Form.FirstOrDefault(x => x.Key == "length").Value.FirstOrDefault();
                col1 = Request.Form.FirstOrDefault(x => x.Key == "order[0][column]").Value.FirstOrDefault();
                sortColumn = Request.Form.FirstOrDefault(x => x.Key == "columns[" + col1 + "]").Value.FirstOrDefault();
                sortColumnDir = Request.Form.FirstOrDefault(x => x.Key == "order[0][dir]").Value.FirstOrDefault();
                search = Request.Form.FirstOrDefault(x => x.Key == "search[value]").Value.FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecord = 0;
                int filteredRecord = 0;
                data = await this.dbContext.CategoryMaster.Where(f => f.isActive == true).ToListAsync();
                if (string.IsNullOrWhiteSpace(search))
                {
                    var res = data.AsQueryable();
                    var v = (from item in res select item);
                    filteredRecord = v.ToList().Count();
                    data = pageSize == -1 ? v.ToList() : v.Skip(skip).Take(pageSize).ToList();
                }
                else
                {
                    var res = data.AsEnumerable().Where(p => (
                       p.Name != null && p.Name.ToLower().Contains(search)
                    || p.Id.ToString().Contains(search))).AsQueryable();
                    var v = (from item in res select item);
                    filteredRecord = v.ToList().Count();
                    data = pageSize == -1 ? v.ToList() : v.Skip(skip).Take(pageSize).ToList();
                }

                totalRecord = filteredRecord;

                return Ok(new
                {
                    draw,
                    recordsFilterd = filteredRecord,
                    recordsTotal = totalRecord,
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = filteredRecord,
                    iDisplayStart = start,
                    data
                });
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
