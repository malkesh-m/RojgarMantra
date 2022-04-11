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
    public class JobDetailsController : Controller
    {
        private IJobDetailsService _jobDetailsService;
        private IDegreeService _degreeService;

        public JobDetailsController(IJobDetailsService jobDetailsService, IDegreeService degreeService)
        {
            _jobDetailsService = jobDetailsService;
            _degreeService = degreeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _jobDetailsService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.Degree = await _degreeService.GetLookup();
            ViewBag.PostDegree = await _degreeService.GetLookupPost();
            if (id == 0)
            {
                JobDetailsAddEditModel result1 = new JobDetailsAddEditModel();
                result1.Id = id;
                ViewBag.Mode = "Add";
                return View(result1);
            }
            ViewBag.Mode = "Update";
            var result = await _jobDetailsService.Get(id);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddEdit(JobDetailsAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState), JsonRequestBehavior.AllowGet));

            var result = await _jobDetailsService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("Placement Drive"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("Placement Drive"), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _jobDetailsService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Placement Drive"));
            else
                return Json(JsonModel.DeleteFailed("Placement Drive"));
        }
    }
}