using RojgarMantra.Core.Models;
using RojgarMantra.Models;
using RojgarMantra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RojgarMantra.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : ApiController
    {
        private IUserEmployerService _employerService;
        private IUserJobSeekerService _userJobSeekerService;
        private IUserTrainingInstituteService _userTrainingInstituteService;

        public RegisterUserController(IUserEmployerService employerService, IUserJobSeekerService userJobSeekerService, IUserTrainingInstituteService userTrainingInstituteService)
        {
            _employerService = employerService;
            _userJobSeekerService = userJobSeekerService;
            _userTrainingInstituteService = userTrainingInstituteService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddEmployer(UserEmployerAddEditModel model)
        {
            var result = await _employerService.Save(model);
            switch (result)
            {
                case "Success":
                    return Json(new JsonResponse { Status = "Success", Date = "", Message = "User created successfully." });
                case "User already exist":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "User already exist." });
                case "Failed":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
            }
            return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddJobSeeker(UserJobSeekerAddEditModel model)
        {
            var result = await _userJobSeekerService.Save(model);
            switch (result)
            {
                case "Success":
                    return Json(new JsonResponse { Status = "Success", Date = "", Message = "User created successfully." });
                case "User already exist":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "User already exist." });
                case "Failed":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
            }
            return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddTrainingInstitute(UserTrainingInstituteAddEditModel model)
        {
                var result = await _userTrainingInstituteService.Save(model);
            switch (result)
            {
                case "Success":
                    return Json(new JsonResponse { Status = "Success", Date = "", Message = "User created successfully." });
                case "User already exist":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "User already exist." });
                case "Failed":
                    return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
            }
            return Json(new JsonResponse { Status = "Error", Date = "", Message = "Unexpected error occured." });
        }       

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployer(int id)
        {
            var result =await _employerService.Get(id);
            return Ok(result);
        }
    }
}
