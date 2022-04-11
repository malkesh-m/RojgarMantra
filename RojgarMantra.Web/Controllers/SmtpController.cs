//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using RojgarMantra.Data;
//using RojgarMantra.Data.Entities;
//using RojgarMantra.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Runtime.Remoting.Contexts;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Xceed.Wpf.Toolkit;

//namespace RojgarMantra.Controllers
//{
//    public class SmtpController : Controller
//    {
//        DbContext_class objDataContext = new DbContext_class();
//        ApplicationDbContext db = new ApplicationDbContext();
//        // GET: Smtp
//        private ApplicationSignInManager _signInManager;
//        private ApplicationUserManager _userManager;
//        public ActionResult Index()
//        {
//            return View();
//        }
//        private void AddErrors(IdentityResult result)
//        {
//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError("", error);
//            }
//        }
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }
//        public ApplicationSignInManager SignInManager
//        {
//            get
//            {
//                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//            }
//            private set
//            {
//                _signInManager = value;
//            }
//        }
//        public async Task<ActionResult> SmtpDetailsCreate(SmtpDetails model)
//        {

           
          
//            if (ModelState.IsValid)
//            {



//                if (string.IsNullOrEmpty(model.Smtpid))
//                {
//                    objDataContext.SmtpDetails.Add(model);
//                    objDataContext.SaveChanges();
//                    return RedirectToAction("Index");
                   
                    
//                }
//                else
//                {
//                    var emp = objDataContext.SmtpDetails.Where(a => a.Smtpid.Equals(model.Smtpid)).SingleOrDefault();
//                //    emp.Host = model.Host;
//                    emp.Emailid = model.Emailid;
//                    emp.Name = model.Name;
//                    emp.Port = model.Port;
//                    emp.username = model.username;
//                    emp.Password = model.Password;
//                    objDataContext.SaveChanges();
                    

//                }

                    
               




//                return View();


//            }
//            return View(model);
//        }
//    }
//}
