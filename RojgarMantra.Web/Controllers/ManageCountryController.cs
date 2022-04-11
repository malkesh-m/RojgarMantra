/*using PagedList;
using RojgarMantra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    public class ManageCountryController : Controller
    {

        CountryDbContext objDataContext = new CountryDbContext();
        // GET: ManageCountry
        public ActionResult Index(string sortOrder)
        {

            return View();
        }
        [HttpGet]
        public ActionResult EditCountry(int? Id)
        {
            if (ModelState.IsValid)
            {
                var CountryName = objDataContext.Countrydetails.FirstOrDefault(c => c.CountryID == Id);
                return View(CountryName);
            }
            return View();


        }
        [HttpPost]
        public ActionResult EditCountry(CountryAdd Model)
        {

            objDataContext.Entry(Model).State = EntityState.Modified;

            objDataContext.SaveChanges();


           


            return RedirectToAction("CountryDetails");
        }
        public ActionResult Paging(int page = 1)
        {
            int recordsPerPage = 2;

            var list = objDataContext.Countrydetails.ToList().ToPagedList(page, recordsPerPage);
            return View(list);
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
            CountryAdd personalDetail = objDataContext.Countrydetails.Find(id);
            objDataContext.Countrydetails.Remove(personalDetail);
            objDataContext.SaveChanges();
            return RedirectToAction("CountryDetails");
        }




        public ActionResult ManageCountryDetails(CountryAdd model)
        {

            if (ModelState.IsValid)
            {
                objDataContext.Countrydetails.Add(model);
                 objDataContext.SaveChanges();
                return RedirectToAction("CountryDetails");
             }



            return View(model);
        }


        public ActionResult SortingCountry(CountryAdd model)
        {

            if (ModelState.IsValid)
            {
                objDataContext.Countrydetails.Add(model);
                objDataContext.SaveChanges();
                return RedirectToAction("CountryDetails");
            }



            return View(model);
        }




        public JsonResult CountryDetails(string searchString, string Sorting_Order, string currentFilter)
        {
  
           
            var Countrys = from s in objDataContext.Countrydetails
                           select s;

            //searching

            //  if (!String.IsNullOrEmpty(searchString))
            //{
               
            //     Countrys = Countrys.Where(s => s.CountryName.Contains(searchString)
            //                            );
            //    return View(Countrys.ToList());
            //}


              //sorting

            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            var countrys = from stu in objDataContext.Countrydetails select stu;
            switch (Sorting_Order)
            {
                case "Name_Description":
                    countrys = countrys.OrderBy(stu => stu.CountryName);
                    break;
               
                default:
                    countrys = countrys.OrderBy(stu => stu.CountryID);
                    break;
            }


           

            return Json(countrys.ToList(), JsonRequestBehavior.AllowGet);


           // return View(objDataContext.Countrydetails.ToList());
        }

        public JsonResult AutoCompleteCity()
        {
            List<CountryAdd> listData = new List<CountryAdd>();
            

            return Json(listData, JsonRequestBehavior.AllowGet);

        }






    }
}*/