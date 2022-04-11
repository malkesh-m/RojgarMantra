var EmployerIndex1 = {
    hideModelCallbackData: undefined,



    init: function () {
        EmployerIndex1.bindGrid();
        $("#BtnAddEmp").click(function () {
            EmployerIndex1.showAddEditModal(EmployerIndex1.refresh, undefined);
        });
        $("#BtnRefresh").click(function () {
            EmployerIndex1.refresh();
        });
    },

    bindGrid: function () {
        $("#TblEmployer").DataTable({
            "sAjaxSource": "/City/Index",
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
                        return "<a href='/City/Edit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='EmployerIndex1.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                /* { "data": "ContactName", "name": "ContactName", "title": "Contact Name", "autoWidth": true },*/
                { "data": "CountryId", "name": "CountryId", "title": "Company Name", "autoWidth": true },
                { "data": "CountryName", "name": "CountryName", "title": "CountryName", "autoWidth": true },
               
            ],
        });
    },

    showAddEditModal: function (hideModelCallback, id = 0) {
        $("#ModalAddEdit").unbind("hidden.bs.modal");
        $("#ModalAddEdit").on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(EmployerIndex1.hideModelCallbackData);
                return;
            }
        });

        // $('#ModalAddEdit').modal('show');
        debugger;
        $.ajax({
            type: "GET",
            url: "/City/Edit?Id=" + id,
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
                EmployerIndex1.refresh();
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