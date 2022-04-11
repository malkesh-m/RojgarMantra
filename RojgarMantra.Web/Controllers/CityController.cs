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
    public class CityController : Controller
    {
        private ICityService _CityService;
        private IDistrictService _DistrictService;
        public CityController(ICityService CityService, IDistrictService DistrictService)
        {
            _CityService = CityService;
            _DistrictService = DistrictService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _CityService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.district = await _DistrictService.GetLookupDistrict();

            if (id == 0)
            {

                ViewBag.Mode = "Add";
                return View();
            }
            ViewBag.Mode = "Update";
            var result = await _CityService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AddEdit(CityAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _CityService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("City"));
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("City"));
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _CityService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("City"));
            else
                return Json(JsonModel.DeleteFailed("City"));
        }
    }
}
