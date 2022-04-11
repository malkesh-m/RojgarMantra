var userIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        userIndex.bindGrid();

        $('#BtnAddUser').click(function () {
            userIndex.showAddEditModal(userIndex.refresh,undefined);
        });

        $('#BtnRefresh').click(function () {
            userIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblUser').DataTable({
                "sAjaxSource": "/User/List",
                "bServerSide": true,
                "bProcessing": true,
                "bSearchable": true,
                "order": [[1, 'asc']],
                "language": {
                    "emptyTable": "No record found.",
                    "processing":
                        '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
                },
                "columns": [
                    {
                        "data": null, "name": "Action", "title": "Action", "orderable": false, "autoWidth": true,
                        "render": function (data, type, row) {
                            return "<a href='/User/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#'  onclick='userIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                        }
                    },
                    { "data": "FirstName", "name": "FirstName", "title": "First Name", "autoWidth": true },
                    { "data": "MiddleName", "name": "MiddleName", "title": "Middle Name", "autoWidth": true },
                    { "data": "LastName", "name": "LastName", "title": "Last Name", "autoWidth": true },
                    { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                ]
        });  
    },

    showAddEditModal: function (hideModelCallback, id) {
        $("#ModalAddEdit").unbind('hidden.bs.modal');
        $("#ModalAddEdit").on('hidden.bs.modal', function (e) {
            if (hideModelCallback) {
                hideModelCallback(userIndex.hideModelCallbackData);
                return;
            }
        });

       // $('#ModalAddEdit').modal('show');

        $.ajax({
            type: "GET",
            url: "/User/AddEdit",
            data: {
                'id': id
            },
            success: function (data) {
                $("#ModalAddEdit .modal-body").html(data);
            },
            error: function () {
                common.showErrorAlert();
            },
            beforeSend: function () {
                $("#ModalAddEdit .modal-body").html('<h3>Loading...</h3>');
            },
            complete: function () {
                //hide loader
            }
        });
    },

    delete: function (id) {
        debugger;
        $.ajax({
            type: "DELETE",
            url: "/User/Delete",
            data: {
                'id': id
            },
            success: function (data) {
                common.showAlert(data);
                userIndex.refresh();
            },
            error: function () {
                common.showErrorAlert();
            },
            beforeSend: function () {
                //$("#ModalAddEdit .modal-body").html('<h2>Loading</h2>');
            },
            complete: function () {
                //hide loader
            }
        });
    },

    refresh: function () {
        $("#TblUser").dataTable().fnDraw();
    }
}