using Microsoft.AspNet.Identity;
using RojgarMantra.Core.Constants;
using RojgarMantra.Core.Models;
using RojgarMantra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    public class JobCategoryController : Controller
    {
        IJobCategoryService _jobCategoryService;

        public JobCategoryController(IJobCategoryService jobCategoryService)
        {
            _jobCategoryService = jobCategoryService;
        }
        // GET: JobCategory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var listoutputModel = await _jobCategoryService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = listoutputModel.RecordsTotal, recordsTotal = listoutputModel.RecordsTotal, data = listoutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var result = await _jobCategoryService.Get(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(JobCategoryAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));
            model.CreatedOnText = User.Identity.GetUserId();
            var result = await _jobCategoryService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                    return Json(JsonModel.UpdateSuccess("JobCategory"));
                else
                    return Json(JsonModel.CreateSuccess("JobCategory"));
            }

            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _jobCategoryService.Delete(id);
            if (result)
            {
                return Json(JsonModel.DeleteSuccess("JobCategory"));
            }
            else
            {
                return Json(JsonModel.DeleteFailed("JobCategory"));
            }
        }
    }
}