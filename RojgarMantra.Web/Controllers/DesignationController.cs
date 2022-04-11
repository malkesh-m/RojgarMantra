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
    public class DesignationController : Controller
    {
        private IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _designationService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            if (id == 0)
            {

                ViewBag.Mode = "Add";
                return View();
            }
            ViewBag.Mode = "Update";
            var result = await _designationService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AddEdit(DesignationAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _designationService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("Designation"));
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("Designation"));
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _designationService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Designation"));
            else
                return Json(JsonModel.DeleteFailed("Designation"));
        }
    }
}