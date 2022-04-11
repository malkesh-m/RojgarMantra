using RojgarMantra.Core.Models;
using RojgarMantra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojgarMantra.Service
{
    public class Common
    {
        public static ListInputModel CreateListInputModel(JqueryDatatableParam model)
        {
            ListInputModel listParam = new ListInputModel
            {
                Echo=model.sEcho,
                Start=model.iDisplayStart,
                Length=model.iDisplayLength,
                SortColumnDir=model.sSortDir_0,
                SortColumn=model.sColumns.Split(',')[model.iSortCol_0],
                Search=model.sSearch

                //Echo = request.Form.GetValues("sEcho").FirstOrDefault(),
                //Start = request.Form.GetValues("iDisplayStart").FirstOrDefault(),
                //Length = request.Form.GetValues("iDisplayLength").FirstOrDefault(),
                //SortColumn = request.Form.GetValues("sColumns[" + request.Form.GetValues("iSortCol_0").FirstOrDefault() + "][name]").FirstOrDefault(),
                //SortColumnDir = request.Form.GetValues("sSortDir_0").FirstOrDefault()
            };

            return listParam;
        }

       
    }
}