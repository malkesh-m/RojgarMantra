var TrainingInstituteIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        TrainingInstituteIndex.bindGrid();
        $("#BtnAddEmp").click(function () {
            TrainingInstituteIndex.showAddEditModal(TrainingInstituteIndex.refresh, undefined);
        });
        $("#BtnRefresh").click(function () {
            TrainingInstituteIndex.refresh();
        });
    },

    bindGrid: function () {
        $("#TblTrainingInstitute").DataTable({
            "sAjaxSource": "/TrainingInstitute/List",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, "asc"]],
            "language": {
                "emptyTable": "No Record Found.",
                "processing": '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span>'
            },
            "columns": [
                {
                    "data": null, "name": "Action", "title": "Action", "orderable": false, "autoWidth": true,
                    "render": function (data, type, row) {
                        return "<a href='/TrainingInstitute/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='TrainingInstituteIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                    //onclick = 'TrainingInstituteIndex.showAddEditModal(TrainingInstituteIndex.refresh,\"" + row.Id + "\")'
                },
                { "data": "TrainingInstituteName", "name": "TrainingInstituteName", "title": "Training Institute Name", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "ContactNumber", "name": "ContactNumber", "title": "Contact Number", "autoWidth": true },
                { "data": "CompanyLink", "name": "CompanyLink", "title": "Company Link", "autoWidth": true },
                { "data": "Address", "name": "Address", "title": "Address", "autoWidth": true },
                { "data": "Designation", "name": "Designation", "title": "Designation", "autoWidth": true },
                /*{ "data": "Role", "name": "Role", "title": "Role", "autoWidth": true },*/
                { "data": "WorkExperience", "name": "WorkExperience", "title": "Work Experience", "autoWidth": true },
            ]
        });
    },

    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/TrainingInstitute/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                TrainingInstituteIndex.refresh();
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
        $("#TblTrainingInstitute").dataTable().fnDraw();
    }
}