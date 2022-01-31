using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NimapInfotech.Entity;
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
                JsonResult json;
                data = await this.dbContext.CategoryMaster.ToListAsync();
                //if (string.IsNullOrWhiteSpace(search))
                //{
                //    var res = result.lstMapMarkers.AsQueryable();
                //    var v = (from item in res select item);
                //    //if (!(string.IsNullOrEmpty(sortColumn) && !(string.IsNullOrEmpty(sortColumnDir))))
                //    //{
                //    //    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                //    //}
                //    filteredRecord = v.ToList().Count();
                //    data = pageSize == -1 ? v.ToList() : v.Skip(skip).Take(pageSize).ToList();
                //}
                //else
                //{
                //    var res = result.lstMapMarkers.AsEnumerable().Where(p => (p.AssetCodeName != null && p.AssetCodeName.ToLower().Contains(search)) ||
                //                 (p.Asset_Name != null && p.Asset_Name.ToLower().Contains(search)) ||
                //                 (p.Job_Code != null && p.Job_Code.ToLower().Contains(search)) ||
                //                 (p.Job_Desc != null && p.Job_Desc.ToLower().Contains(search)) ||
                //                 (p.Asset_Type != null && p.Asset_Type.ToLower().Contains(search)) ||
                //                 (p.LastReportDate != null && p.LastReportDate.ToLower().Contains(search)) ||
                //                 (p.Asset_Status != null && p.Asset_Status.ToLower().Contains(search)) ||
                //                 (p.AvgEngineOnHours != null && p.AvgEngineOnHours.ToLower().Contains(search)) ||
                //                 (p.WorkingHrs != null && p.WorkingHrs.ToLower().Contains(search)) ||
                //                 (p.WorkDoneHrs != null && p.WorkDoneHrs.ToLower().Contains(search))
                //           ).AsQueryable();
                //    var v = (from item in res select item);
                //    if (!(string.IsNullOrEmpty(sortColumn) && !(string.IsNullOrEmpty(sortColumnDir))))
                //    {
                //        //v = v.OrderBy(sortColumn + " " + sortColumnDir);
                //        //v = v.OrderBy(sortColumn);
                //    }
                //    //if (!(string.IsNullOrEmpty(sortColumn)))
                //    //v = v.OrderBy(a => a. sortColumn);
                //    filteredRecord = v.ToList().Count();
                //    data = pageSize == -1 ? v.ToList() : v.Skip(skip).Take(pageSize).ToList();
                //}

                filteredRecord = totalRecord;

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
