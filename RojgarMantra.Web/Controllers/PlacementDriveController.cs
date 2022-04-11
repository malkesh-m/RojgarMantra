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
    public class PlacementDriveController : Controller
    {
        private IPlacementDriveService _placementDriveService;
        private IDegreeService _degreeService;
        private ISelectionProcessService _selectionProcessService;

        public PlacementDriveController(IPlacementDriveService placementDriveService, IDegreeService degreeService, ISelectionProcessService selectionProcessService)
        {
            _placementDriveService = placementDriveService;
            _degreeService = degreeService;
            _selectionProcessService = selectionProcessService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _placementDriveService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.Degree =await _degreeService.GetLookupAll();
            ViewBag.selProcess = await _selectionProcessService.GetLookup();
            if (id == 0)
            {
                PlacementDriveAddEditModel result1 = new PlacementDriveAddEditModel();
                result1.Id = id;
                ViewBag.Mode = "Add";
                return View(result1);
            }
            ViewBag.Mode = "Update";
            var result = await _placementDriveService.Get(id);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddEdit(PlacementDriveAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState), JsonRequestBehavior.AllowGet));

            var result = await _placementDriveService.Save(model);
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
            var result = await _placementDriveService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Placement Drive"));
            else
                return Json(JsonModel.DeleteFailed("Placement Drive"));
        }
    }
}