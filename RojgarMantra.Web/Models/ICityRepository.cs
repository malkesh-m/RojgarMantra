using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Models
{
    interface ICityRepository
    {

        void InsertEmployee( Citydetails Employee); // C

        IEnumerable< Citydetails> GetEmployees(); // R

         Citydetails GetEmployeeByID(int EmployeeId); // R

        void UpdateEmployee( Citydetails Employee); //U

        void DeleteEmployee(int EmployeeId); //D

      //  void SearchUsers(String Districtname);
        void SortUsers( Citydetails Employee);
        IEnumerable<Citydetails> SearchUsers(string SearchString);

      //  IEnumerable<Citydetails> SortUsers(IEnumerable<Citydetails> users);

        void Save();
    }
}
