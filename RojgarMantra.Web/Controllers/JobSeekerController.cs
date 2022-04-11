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
    public class JobSeekerController : Controller
    {
        private IUserJobSeekerService _userJobSeekerService;
        private IComanService _comanService;
        private IDesignationService _designationService;
        private IRoleService _roleService;
        private IDegreeService _degreeService;
        private ICityService _cityService;
        private IStateService _stateService;
        private ICountryService _countryService;
        public JobSeekerController(IUserJobSeekerService userJobSeekerService, IComanService comanService, IDesignationService designationService, IRoleService roleService,
            IDegreeService degreeService, ICityService cityService, IStateService stateService, ICountryService countryService)
        {
            _userJobSeekerService = userJobSeekerService;
            _comanService = comanService;
            _designationService = designationService;
            _roleService = roleService;
            _degreeService = degreeService;
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
            var ListOutputModel = await _userJobSeekerService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            ViewBag.YearList = _comanService.GetLookupForYearSelection();
            ViewBag.Designations = await _designationService.GetLookup();
            ViewBag.Roles =await _roleService.GetLookup();
            ViewBag.Degree = await _degreeService.GetLookup();
            ViewBag.PostDegree = await _degreeService.GetLookupPost();
            ViewBag.totalExperience = _comanService.GetLookupTotalExperience();
            ViewBag.noticePeriod = _comanService.GetLookupNoticePeriod();
            ViewBag.languages = _comanService.GetLookupLanguages();
            ViewBag.courseCompletion = _comanService.GetLookupCourseCompletion();
            ViewBag.marriedStatus = _comanService.GetLookupMarriedStatus();
            ViewBag.city =await _cityService.GetLookupCity();
            ViewBag.state =await _stateService.GetLookupState();
            ViewBag.country =await _countryService.GetLookupCountry();
            if (id == 0)
            {
                UserJobSeekerAddEditModel result1 = new UserJobSeekerAddEditModel();
                result1.Id = id;
                ViewBag.Mode = "Add";
                return View(result1);
            }
            ViewBag.Mode = "Update";
            var result = await _userJobSeekerService.Get(id);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddEdit(UserJobSeekerAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState), JsonRequestBehavior.AllowGet));

            var result = await _userJobSeekerService.Save(model);
            switch (result)
            {
                case "Success":
                    if (model.Id != 0)
                    {
                        return Json(JsonModel.UpdateSuccess("Candidate"));
                    }
                    else
                    {
                        return Json(JsonModel.CreateSuccess("Candidate"));
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
            var result = await _userJobSeekerService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("JobSeeker"));
            else
                return Json(JsonModel.DeleteFailed("JobSeeker"));
        }
    }
}