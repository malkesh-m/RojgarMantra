var EIndex = {
    hideModelCallbackData: undefined,



    init: function () {
        EIndex.bindGrid();
        $("#BtnAddEmp").click(function () {
            EIndex.showAddEditModal(EIndex.refresh, undefined);
        });
        $("#BtnRefresh").click(function () {
            EIndex.refresh();
        });
    },

    bindGrid: function () {
        $("#TblEmployer").DataTable({
            "sAjaxSource": "/Employer/List",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, "asc"]],
            "language": {
                "emptyTable": "No Record Found.",
                "processing": '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i>'
            },
            "columns": [
                {
                    "data": null, "name": "Action", "title": "Action", "orderable": false, "autoWidth": true,
                    "render": function (data, type, row) {
                        return "<a href='/Employer/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='EIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                /* { "data": "ContactName", "name": "ContactName", "title": "Contact Name", "autoWidth": true },*/
                { "data": "CompanyName", "name": "CompanyName", "title": "Company Name", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "ContactNumber", "name": "ContactNumber", "title": "Contact Number", "autoWidth": true },
                { "data": "CompanyLink", "name": "CompanyLink", "title": "Company Link", "autoWidth": true },
                { "data": "Address", "name": "Address", "title": "Address", "autoWidth": true },
                { "data": "Designation", "name": "Designation", "title": "Designation", "autoWidth": true },
                /*  { "data": "Role", "name": "Role", "title": "Role", "autoWidth": true },*/
                { "data": "WorkExperience", "name": "WorkExperience", "title": "Work Experience", "autoWidth": true },
            ],
        });
    },

    showAddEditModal: function (hideModelCallback, id = 0) {
        $("#ModalAddEdit").unbind("hidden.bs.modal");
        $("#ModalAddEdit").on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(EIndex.hideModelCallbackData);
                return;
            }
        });

        // $('#ModalAddEdit').modal('show');
        debugger;
        $.ajax({
            type: "GET",
            url: "/Employer/AddEdit?Id=" + id,
            success: function (data) {
                $("#ModalAddEdit .modal-body").html(data);
            },
            error: function (error) {
                common.showErrorAlert();
            },
            beforeSend: function () {
                $("#ModalAddEdit .modal-body").html('<h3>Loading...</h3>');
            },
            complete: function () {
                //
            }
        });
    },

    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/Employer/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                EIndex.refresh();
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
        $("#TblEmployer").dataTable().fnDraw();
    }
}