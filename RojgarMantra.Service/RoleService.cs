using Microsoft.AspNetCore.Http;
using RojgarMantra.Core.Models;
using RojgarMantra.Data.Entities;
using RojgarMantra.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace RojgarMantra.Service
{
    public interface IRoleService
    {
        Task<ListOutputModel> GetAll(ListInputModel model);
        Task<bool> Delete(int id);
        Task<RoleAddEditModel> Get(int id);
        Task<bool> Save(RoleAddEditModel model);
        Task<IEnumerable<LookupModel>> GetLookup();
    }
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ListOutputModel> GetAll(ListInputModel model)
        {
            var Roles = _uow.RoleRepository.Query();

            //search job
            if (!string.IsNullOrEmpty(model.Search))
            {
                Roles = Roles.Where(x => x.Name.ToLower().Contains(model.Search.ToLower()));
            }

            //sort column
            if (!(string.IsNullOrEmpty(model.SortColumn) && string.IsNullOrEmpty(model.SortColumnDir)))
            {
                Roles = Roles.OrderBy(model.SortColumn + " " + model.SortColumnDir);
            }

            int recordsTotal = await Roles.CountAsync();

            var data = Roles.Skip(model.Start).Take(model.Length).AsEnumerable().
                Select(x => new RoleListModel
                {
                    Id = x.Id,
                    Name = x.Name.ToString()

                    /* CreatedBy = x.CreatedBy.ToString(),
                 CreatedOnText = x.CreatedOn.ToString("dd/MM/yyyyy"),
                 ModifiedBy = x.ModifiedBy.ToString(),
                 ModifiedOnText = x.ModifiedOn.ToString("dd/MM/yyyyy")*/
                }).ToList();

            return new ListOutputModel
            {
                Data = data,
                RecordsTotal = recordsTotal
            };
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _uow.RoleRepository.Delete(id);

            return await _uow.Save();
        }

        public async Task<RoleAddEditModel> Get(int id)
        {
            var jobs = await _uow.RoleRepository.Get(id);
            var result = new RoleAddEditModel
            {
                Id = jobs.Id,
                Name = jobs.Name,
                //CreatedBy = jobs.CreatedBy,
                //CreatedOn = jobs.CreatedOn,
                //ModifiedBy = jobs.ModifiedBy,
                //ModifiedOn = jobs.ModifiedOn
            };

            return result;
        }


        public async Task<bool> Save(RoleAddEditModel model)
        {
            Role Role;
            //var task = "Add";
            if (model.Id == 0)
            {
                Role = new Role();
                await _uow.RoleRepository.Add(Role);
            }
            else
            {
                Role = await _uow.RoleRepository.Get(model.Id);
                await _uow.RoleRepository.Update(Role);
                //  task = "Update";
            }

            Role.Name = model.Name;
            /* if (task == "Add")
             {
                 job.CreatedBy = model.CreatedOnText;
                 job.CreatedOn = DateTime.Now;
             }
             job.ModifiedBy = model.CreatedOnText;
             job.ModifiedOn = DateTime.Now;*/

            return await _uow.Save();
        }

        public async Task<IEnumerable<LookupModel>> GetLookup()
        {
            var result = await _uow.RoleRepository.Query().Select(x =>
                new LookupModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return result;
        }
    }
}
