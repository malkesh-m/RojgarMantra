/*using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RojgarMantra.Models
{
    public class CityRepositiry : ICityRepository
    {
        private CityDbContext DBcontext;

        public CityRepositiry(CityDbContext objempcontext)

        {

            this.DBcontext = objempcontext;

        }
        public void DeleteEmployee(int CityId)
        {
            Citydetails user = DBcontext.Citydetails.Find(CityId);

            DBcontext.Citydetails.Remove(user);

            DBcontext.SaveChanges();
        }

        public Citydetails GetEmployeeByID(int CityId)
        {
            return DBcontext. Citydetails.Find(CityId);
        }

        public IEnumerable<Citydetails> GetEmployees()
        {
            return DBcontext. Citydetails.ToList();
        }

        public void InsertEmployee(Models.Citydetails Citydetails)
        {
            DBcontext. Citydetails.Add(Citydetails);

            DBcontext.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SearchUsers(string Districtname)
        {
            throw new NotImplementedException();
        }

        public void SortUsers(Citydetails Citydetails)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Citydetails> SortUsers(IEnumerable<Citydetails> users)
        {
            return users.OrderBy(x => x.CityName);
        }

        public void UpdateEmployee(Citydetails Citydetails)
        {
            DBcontext.Entry( Citydetails).State = EntityState.Modified;

            DBcontext.SaveChanges();
        }

        IEnumerable<Citydetails> ICityRepository.SearchUsers(string SearchString)
        {
            return DBcontext.Citydetails.Where(x => x.CityName.Contains(SearchString));
        }
    }
}*/