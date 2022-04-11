using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using RojgarMantra.Core.Models;
using RojgarMantra.Data;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Web.Mvc;

namespace RojgarMantra.Service
{
    public interface IComanService
    {
        List<SelectListItem> GetLookupForYearSelection();
        List<SelectListItem> GetLookupStatus();
        List<SelectListItem> GetLookupTotalExperience();
        List<SelectListItem> GetLookupCourseCompletion();
        List<SelectListItem> GetLookupNoticePeriod();
        List<SelectListItem> GetLookupLanguages();
        List<SelectListItem> GetLookupMarriedStatus();
    }

    public class ComanService : IComanService
    {
        public ComanService()
        {
        }

        public List<SelectListItem> GetLookupForYearSelection()
        {
            var selectListItems = new List<SelectListItem>();
            for (int year = DateTime.Now.Year; year >= (DateTime.Now.Year-50); year--)
            {
                selectListItems.Add(new SelectListItem() { Text = year.ToString(), Value = year.ToString() });
            }
            return selectListItems;
        }

        public List<SelectListItem> GetLookupStatus()
        { 
            var selectListItems = new List<SelectListItem>()
            { new SelectListItem { Text = "Active", Value = "Active" }, new SelectListItem { Text = "Deactive", Value = "Deactive" } };
            return selectListItems;
        }

        public List<SelectListItem> GetLookupMarriedStatus()
        {
            var selectListItems = new List<SelectListItem>()
            { new SelectListItem { Text = "Married", Value = "Married" }, new SelectListItem { Text = "Single", Value = "Single" } };
            return selectListItems;
        }

        public List<SelectListItem> GetLookupTotalExperience()
        {
            var selectListItems = new List<SelectListItem>();
            for (int year = 1; year <= 30; year++)
            {
                selectListItems.Add(new SelectListItem() { Text = year.ToString() + " Year", Value = year.ToString() });
            }
            return selectListItems;
        }


        public List<SelectListItem> GetLookupCourseCompletion()
        {
            var selectListItems = new List<SelectListItem>();
            for (int month = 1; month <= 24; month++)
            {
                selectListItems.Add(new SelectListItem() { Text = month.ToString() + " Month", Value = month.ToString() });
            }
            return selectListItems;
        }


        public List<SelectListItem> GetLookupNoticePeriod()
        {
            var selectListItems = new List<SelectListItem>();
            for (int day = 1; day <= 90; day++)
            {
                selectListItems.Add(new SelectListItem() { Text = day.ToString() + " Day", Value = day.ToString() });
            }
            return selectListItems;
        }

        public List<SelectListItem> GetLookupLanguages()
        {
            var selectListItems = new List<SelectListItem>()
            { 
                new SelectListItem { Text = "English", Value = "English" },
                new SelectListItem { Text = "Gujarati", Value = "Gujarati" },
                new SelectListItem { Text = "Marathi", Value = "Marathi" },
                new SelectListItem { Text = "Tamil", Value = "Tamil" },
                new SelectListItem { Text = "Telagu", Value = "Telagu" },
                new SelectListItem { Text = "Kannad", Value = "Kannad" }
            };
            return selectListItems;
        }
    }
}
