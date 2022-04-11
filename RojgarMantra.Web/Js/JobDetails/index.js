var JobDetailsIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        JobDetailsIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            JobDetailsIndex.showAddEditModal(JobDetailsIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            JobDetailsIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblJobDetails').DataTable({
            "sAjaxSource": "/JobDetails/List",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "emptyTable": "No record found.",
                "processing": '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
            },
            "columns": [
                {
                    "data": null, "name": "Action", "title": "Action", "orderable": false, "autoWidth": true,
                    "render": function (data, type, row) {
                        return "<a href='/JobDetails/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='JobDetailsIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "JobTitle", "name": "JobTitle", "title": "Job Title", "autoWidth": true },
                { "data": "FirstName", "name": "FirstName", "title": "First Name", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "CompanyName", "name": "CompanyName", "title": "Company Name", "autoWidth": true },
                { "data": "ContactNumber", "name": "ContactNumber", "title": "Contact Number", "autoWidth": true },
                { "data": "Skills", "name": "Skills", "title": "Skills", "autoWidth": true },
                { "data": "JobType", "name": "JobType", "title": "Job Type", "autoWidth": true },
                { "data": "NumberOfOpenings", "name": "NumberOfOpenings", "title": "Number Of Openings", "autoWidth": true },
                { "data": "LocationOfJob", "name": "LocationOfJob", "title": "Location Of Job", "autoWidth": true },
                { "data": "MinWorkExperience", "name": "MinWorkExperience", "title": "Min. Work Experience", "autoWidth": true },
                { "data": "MaxWorkExperience", "name": "MaxWorkExperience", "title": "Max. Work Experience", "autoWidth": true },
            ]
        });
    },


    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/JobDetails/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                JobDetailsIndex.refresh();
            },
            error: function () {
                common.showErrorAlert();
            },
            beforeSend: function () {

            },
            complete: function () {

            }
        });
    },
    refresh: function () {
        $("#TblJobDetails").dataTable().fnDraw();
    }
}