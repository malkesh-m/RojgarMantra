using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojgarMantra.Models
{
    interface IDistrictRepository
    {

      

        void InsertEmployee(Districtdetails Employee); // C

        IEnumerable<Districtdetails> GetEmployees(); // R

        Districtdetails GetEmployeeByID(int EmployeeId); // R

        void UpdateEmployee(Districtdetails Employee); //U

        void DeleteEmployee(int EmployeeId); //D

        void SearchUsers(String Districtname);
        void SortUsers(Districtdetails Employee);

        void Save();
    }
}
