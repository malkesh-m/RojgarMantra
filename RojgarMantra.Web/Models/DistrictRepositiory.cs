/*using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class DistrictRepositiory : IDistrictRepository
    {

        private DistrictDbcontext DBcontext;

        public DistrictRepositiory(DistrictDbcontext objempcontext)

        {

            this.DBcontext = objempcontext;

        }
        public void DeleteEmployee(int DistrictId)
        {
            Districtdetails user = DBcontext.Districtdetails.Find(DistrictId);

            DBcontext.Districtdetails.Remove(user);

            DBcontext.SaveChanges();
        }

        public Districtdetails GetEmployeeByID(int DistrictId)
        {
           return DBcontext.Districtdetails.Find(DistrictId);
        }

        public IEnumerable<Models.Districtdetails> GetEmployees()
        {
            return DBcontext.Districtdetails.ToList();
        }

        public void InsertEmployee(Models.Districtdetails districtdetails)
        {
            DBcontext.Districtdetails.Add(districtdetails);

            DBcontext.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SearchUsers()
        {
            throw new NotImplementedException();
        }

        public void SearchUsers(string Districtname)
        {
            throw new NotImplementedException();
        }

        public void SortUsers(Districtdetails Employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Districtdetails districtdetails)
        {
            DBcontext.Entry(districtdetails).State = EntityState.Modified;

            DBcontext.SaveChanges();
        }

        
    }
}*/