var JobAlertDetailsIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        JobAlertDetailsIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            JobAlertDetailsIndex.showAddEditModal(JobAlertDetailsIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            JobAlertDetailsIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblJobAlertDetails').DataTable({
            "sAjaxSource": "/JobAlertDetails/List",
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
                        return "<a href='/JobAlertDetails/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='JobAlertDetailsIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "NameOfJobAlert", "name": "NameOfJobAlert", "title": "Name Of JobAlert", "autoWidth": true },
                { "data": "Designation", "name": "Designation", "title": "Designation", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "YearOfExperience", "name": "YearOfExperience", "title": "Year Of Experience", "autoWidth": true },
                { "data": "JobCategory", "name": "JobCategory", "title": "JobCategory", "autoWidth": true },
                { "data": "WorkExperience", "name": "WorkExperience", "title": "Work Experience", "autoWidth": true },
                { "data": "Role", "name": "Role", "title": "Role", "autoWidth": true },
                { "data": "Skills", "name": "Skills", "title": "Skills", "autoWidth": true },
                { "data": "NoticePeriod", "name": "NoticePeriod", "title": "Notice Period", "autoWidth": true },
            ]
        });
    },


    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/JobAlertDetails/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                JobAlertDetailsIndex.refresh();
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
        $("#TblJobAlertDetails").dataTable().fnDraw();
    }
}