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
    public class EmployerController : Controller
    {
        private IUserEmployerService _userEmployerService;
        private IDesignationService _designationService;

        public EmployerController(IUserEmployerService userEmployerService, IDesignationService designationService)
        {
            _userEmployerService = userEmployerService;
            _designationService = designationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _userEmployerService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.Designations = await _designationService.GetLookup();
            if (id == 0)
            {

                ViewBag.Mode = "Add";
                return View();
            }
            ViewBag.Mode = "Update";
            var result = await _userEmployerService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AddEdit(UserEmployerAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _userEmployerService.Save(model);
            switch (result)
            {
                case "Success":
                    if (model.Id != 0)
                    {
                        return Json(JsonModel.UpdateSuccess("Employer"));
                    }
                    else
                    {
                        return Json(JsonModel.CreateSuccess("Employer"));
                    }
                case "User already exist":
                    return Json(new JsonModel(JsonType.Error, "Create", "User already exist" + " " + GlobalConstant.CreateFailed));
                case "Failed":
                    return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
            }

            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

     
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _userEmployerService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Employer"));
            else
                return Json(JsonModel.DeleteFailed("Employer"));
        }
    }
}