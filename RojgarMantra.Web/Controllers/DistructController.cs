/*using RojgarMantra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    public class DistructController : Controller
    {

        CountryDbContext objDataContext = new CountryDbContext();
        StateDbContext objDataState = new StateDbContext();
        DistrictDbcontext objdisctcontext = new DistrictDbcontext();

        private IDistrictRepository Idist;

        public DistructController()

        {
            this.Idist = new DistrictRepositiory(new DistrictDbcontext());


        }
    
            // GET: Distruct
            public ActionResult Index(string searchString, string Sorting_Order )
        {

            var State = from s in objdisctcontext.Districtdetails
                        select s;

            //searching

            if (!String.IsNullOrEmpty(searchString))
            {

                State = State.Where(s => s.StateName.Contains(searchString) || s.CountryName.Contains(searchString)||s.DistrictName.Contains(searchString)
                                       );
                return View(State.ToList());
            }



            //sorting

            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            var countrys = from stu in objdisctcontext.Districtdetails select stu;
            switch (Sorting_Order)
            {
                case "Name_Description":
                    countrys = countrys.OrderBy(stu => stu.CountryName);
                    break;

                default:
                    countrys = countrys.OrderBy(stu => stu.DistrictName);
                    break;
            }

            return View(countrys.ToList());
            //  ViewBag.Categories = objDataState.Statedetails.ToList();

            var list = Idist.GetEmployees().ToList();

         //   return View(list);
        }

        // GET: Distruct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Distruct/Create
        public ActionResult Create()
        {
           
            return View(new Districtdetails());
        }

        // POST: Distruct/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Districtdetails objdist)
        {

            try

            {

                var District = new Districtdetails();



                District.CountryName = objdist.CountryName;

                District.StateName = objdist.StateName;

                District.DistrictName = objdist.DistrictName;



                Idist.InsertEmployee(District); // Passing data to InsertEmployee of EmployeeRepository

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }

        }

        // GET: Distruct/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var objdist = Idist.GetEmployeeByID(id); // getting records by id GetEmployeeByID(ID)

                var District = new Districtdetails();


                District.DistrictID = objdist.DistrictID;

                District.CountryName = objdist.CountryName;

                District.StateName = objdist.StateName;

                District.DistrictName = objdist.DistrictName;



                return View(District);



            }
            catch
            {
                return View();
            }
        }

        // POST: Distruct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Districtdetails objdist)
        {
            try
            {

                var District = new Districtdetails();

                Idist.UpdateEmployee(objdist); // calling UpdateEmployee method of EmployeeRepository

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }



        

    }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objemp = Idist.GetEmployeeByID(id); // calling GetEmployeeByID method of EmployeeRepository

            return View(objemp);
           
        }

        // POST: Distruct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                Idist.DeleteEmployee(id); // calling DeleteEmployee method of EmployeeRepository

               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
*/