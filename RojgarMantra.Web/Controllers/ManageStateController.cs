/*using RojgarMantra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    
   
    public class ManageStateController : Controller
    {
        CountryDbContext objDataContext = new CountryDbContext();
        StateDbContext objDataState = new StateDbContext();
        // GET: ManageState
        public ActionResult Index()
        {
            //ViewBag.Categories = objDataContext.Countrydetails.ToList();
            return View();
           
        }

        public ActionResult AddState(statedetails model)
        {
            ViewBag.Categories = objDataContext.Countrydetails.ToList();
            if (ModelState.IsValid)
            {
                
                objDataState.Statedetails.Add(model);
                objDataState.SaveChanges();
                return RedirectToAction("ViewStatedetails");

            }
          
            return View();

           


        }


        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryAdd personalDetail = objDataContext.Countrydetails.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            statedetails personalDetail = objDataState.Statedetails.Find(id);
            objDataState.Statedetails.Remove(personalDetail);
            objDataState.SaveChanges(); 
            return RedirectToAction("ViewStatedetails");
        }


        [HttpGet]
        public ActionResult EditState(int? Id)
        {
            if (ModelState.IsValid)
            {
                var StateName = objDataState.Statedetails.FirstOrDefault(c => c.StateID == Id);
               
                return View(StateName);
            }
            return View();


        }
        [HttpPost]
        public ActionResult EditState(statedetails model)
        {

          
            objDataState.Entry(model).State = EntityState.Modified;

            objDataState.SaveChanges();


            return RedirectToAction("ViewStatedetails");
        }



        public ActionResult ViewStatedetails(statedetails model, string searchString, string Sorting_Order)
        {

            var State = from s in objDataState.Statedetails
                           select s;

            //searching

            if (!String.IsNullOrEmpty(searchString))
            {

                State = State.Where(s => s.StateName.Contains(searchString)||s.CountryName.Contains(searchString)
                                       );
                return View(State.ToList());
            }
            //sorting
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            var countrys = from stu in objDataState.Statedetails select stu;
            switch (Sorting_Order)
            {
                case "Name_Description":
                    countrys = countrys.OrderBy(stu => stu.StateName);
                    break;

                default:
                    countrys = countrys.OrderBy(stu => stu.StateID);
                    break;
            }




            return View(countrys.ToList());

         //   return View(objDataState.Statedetails.ToList());

            



        }
    }
}*/