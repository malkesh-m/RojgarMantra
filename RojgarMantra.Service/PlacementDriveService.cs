using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace RojgarMantra.Service
{
    public interface IPlacementDriveService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Save(PlacementDriveAddEditModel model);
        Task<PlacementDriveAddEditModel> Get(int id);
        Task<bool> Delete(int id);
    }
    public class PlacementDriveService : IPlacementDriveService
    {

        private IUnitOfWork _uow;
        public PlacementDriveService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var emp = _uow.PlacementDriveRepository.Query();

            if (!string.IsNullOrEmpty(model.Search))
            {
                emp = emp.Where(x => x.JobTitle.ToLower().Contains(model.Search.ToLower())
                         || x.CompanyName.ToLower().Contains(model.Search.ToLower())
                         || x.EligibleCoursesCertifications.ToLower().Contains(model.Search.ToLower())
                         || x.Degree.Name.ToLower().Contains(model.Search.ToLower())
                         || x.SelectionProcess.Name.ToLower().Contains(model.Search.ToLower())
                         || x.Venue.ToLower().Contains(model.Search.ToLower())
                         || x.JobLocation.ToLower().Contains(model.Search.ToLower())
                         || x.PrimaryCoOrdinatorName.Equals(model.Search));
            }

            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                emp = emp.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await emp.CountAsync();

                var data = emp.Skip(model.Start).Take(model.Length).AsNoTracking().Select(x => new PlacementDriveListModel
                {
                    Id = x.Id,
                    JobTitle = x.JobTitle,
                    JobLocation = x.JobLocation,
                    NumberOfVacancies = x.NumberOfVacancies,
                    RequiredQualification = x.Degree.Name,
                    SelectionProcess = x.SelectionProcess.Name,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    PrimaryCoOrdinatorName = x.PrimaryCoOrdinatorName,
                    CoOrdinatorNumber = x.CoOrdinatorNumber,

                    Timings = x.Timings
                }).ToList();
                return new ListOutputModel
                {
                    Data = data,
                    RecordsTotal = recordsTotal
                };


          
        }

        public async Task<bool> Save(PlacementDriveAddEditModel model)
        {
            PlacementDrive placementDrive;

            if (model.Id == 0)
            {
                placementDrive = new PlacementDrive();
                await _uow.PlacementDriveRepository.Add(placementDrive);
            }
            else
            {
                placementDrive = await _uow.PlacementDriveRepository.Get(model.Id);
                await _uow.PlacementDriveRepository.Update(placementDrive);
            }
            placementDrive.Id = model.Id;
            placementDrive.UserId = model.UserId;
            placementDrive.JobTitle = model.JobTitle;
            placementDrive.CompanyName = model.CompanyName;
            placementDrive.NumberOfVacancies = model.NumberOfVacancies;
            placementDrive.FromDate = model.FromDate;
            placementDrive.ToDate = model.ToDate;
            placementDrive.Package = model.Package;
            placementDrive.DegreeId = Convert.ToInt32(model.RequiredQualification);
            placementDrive.SelectionProcessId = Convert.ToInt32(model.SelectionProcess);
            placementDrive.PrimaryCoOrdinatorName = model.PrimaryCoOrdinatorName;
            placementDrive.CoOrdinatorNumber =Convert.ToDouble(model.CoOrdinatorNumber);
            placementDrive.CoOrdinatorAlternateNumber = Convert.ToDouble(model.CoOrdinatorAlternateNumber);
            placementDrive.Venue = model.Venue;
            placementDrive.EligibleCoursesCertifications = model.EligibleCoursesCertifications;
            placementDrive.JobLocation = model.JobLocation;
            placementDrive.Timings = model.Timings;
            return await _uow.Save();
        }

        public async Task<PlacementDriveAddEditModel> Get(int id)
        {
            var placementDrive = await _uow.PlacementDriveRepository.Get(id);
            var result = new PlacementDriveAddEditModel
            {
                Id = placementDrive.Id,
                UserId = placementDrive.UserId,
                JobTitle = placementDrive.JobTitle,
                CompanyName = placementDrive.CompanyName,
                NumberOfVacancies = placementDrive.NumberOfVacancies,
                FromDate = Convert.ToDateTime(placementDrive.FromDate),
                ToDate = Convert.ToDateTime(placementDrive.ToDate),
                Package = placementDrive.Package,
                RequiredQualification = Convert.ToString(placementDrive.DegreeId),
                SelectionProcess = Convert.ToString(placementDrive.SelectionProcessId),
                PrimaryCoOrdinatorName = placementDrive.PrimaryCoOrdinatorName,
                CoOrdinatorNumber = placementDrive.CoOrdinatorNumber,
                CoOrdinatorAlternateNumber = placementDrive.CoOrdinatorAlternateNumber,
                Venue = placementDrive.Venue,
                EligibleCoursesCertifications = placementDrive.EligibleCoursesCertifications,
                JobLocation = placementDrive.JobLocation,
                Timings = placementDrive.Timings,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.PlacementDriveRepository.Delete(id);

            return await _uow.Save();
        }
    }
}
