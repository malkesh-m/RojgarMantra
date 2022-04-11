using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RojgarMantra.Core.Constants;
using RojgarMantra.Core.Models;
using RojgarMantra.Models;
using RojgarMantra.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    
    public class UserController : Controller
    {
        readonly IUserService _userService;
        private IComanService _comanService;
        private IDesignationService _designationService;
        private IRoleService _roleService;
        private ICityService _cityService;
        private IStateService _stateService;
        private ICountryService _countryService;
        public UserController(IUserService userService, IComanService comanService, IDesignationService designationService, IRoleService roleService
            , ICityService cityService, IStateService stateService, ICountryService countryService)
        {
            _userService = userService;
            _comanService = comanService;
            _designationService = designationService;
            _roleService = roleService;
            _cityService = cityService;
            _stateService = stateService;
            _countryService = countryService;
        }
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var listOutputModel = await _userService.GetPage(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = listOutputModel.RecordsTotal, recordsTotal = listOutputModel.RecordsTotal, data = listOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

    /*    [HttpGet]
        public async Task<PartialViewResult> AddEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return PartialView("/Views/User/_AddEdit.cshtml");

            return PartialView("/Views/User/_AddEdit.cshtml", await _userService.Get(id));
        }*/

        [HttpGet]
        public async Task<ActionResult> AddEdit(string id)
        {
            ViewBag.status = _comanService.GetLookupStatus();
            ViewBag.Designations = await _designationService.GetLookup();
            ViewBag.Roles = await _roleService.GetLookup();
            ViewBag.city = await _cityService.GetLookupCity();
            ViewBag.state = await _stateService.GetLookupState();
            ViewBag.country = await _countryService.GetLookupCountry();
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            var result = await _userService.Get(id);

            ViewBag.Cities = await Lookup();


            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddEdit(UserAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));
          
            var result = await _userService.Save(model);
            if (result)
            {
                if (!string.IsNullOrEmpty(model.Id))
                    return Json(JsonModel.UpdateSuccess("User"));
                else
                    return Json(JsonModel.CreateSuccess("User"));
            }

            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(string id)
        {
            var result =await _userService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("User"));
            else
                return Json(JsonModel.DeleteFailed("User"));
        }

        public async Task<IEnumerable<SelectListItem>> Lookup()
        {
            return (await _userService.GetLookup()).Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
        }
    }
}