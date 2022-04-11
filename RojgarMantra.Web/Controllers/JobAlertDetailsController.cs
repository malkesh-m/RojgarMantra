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
    public class JobAlertDetailsController : Controller
    {
        private IJobAlertDetailsService _jobAlertDetailsService;
        private IJobCategoryService _jobCategoryService;

        public JobAlertDetailsController(IJobAlertDetailsService JobAlertDetailsService, IJobCategoryService jobCategoryService)
        {
            _jobAlertDetailsService = JobAlertDetailsService;
            _jobCategoryService = jobCategoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _jobAlertDetailsService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.JobCategory = await _jobCategoryService.GetLookup();
            if (id == 0)
            {
                JobAlertDetailsAddEditModel result1 = new JobAlertDetailsAddEditModel();
                result1.Id = id;
                ViewBag.Mode = "Add";
              
                return View(result1);
            }
            ViewBag.Mode = "Update";
            var result = await _jobAlertDetailsService.Get(id);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddEdit(JobAlertDetailsAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState), JsonRequestBehavior.AllowGet));

            var result = await _jobAlertDetailsService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("Job Alert Details"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("Job Alert Details"), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _jobAlertDetailsService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Job Alert Details"));
            else
                return Json(JsonModel.DeleteFailed("Job Alert Details"));
        }

        public async Task<IEnumerable<SelectListItem>> Lookup()
        {
                var selectListItems = new List<SelectListItem>();
            foreach (var element in await _jobCategoryService.GetLookup())
                {
                    selectListItems.Add(new SelectListItem() { Text = element.Name, Value =element.Id.ToString() });
                }
                return selectListItems;
            
        }
    }
}