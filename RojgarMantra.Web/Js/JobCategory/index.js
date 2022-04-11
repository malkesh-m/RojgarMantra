var jobIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        jobIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            jobIndex.showAddEditModal(jobIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            jobIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblJob').DataTable({
            "sAjaxSource": "/JobCategory/List",
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
                        return "<a href='/JobCategory/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='jobIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "Name", "name": "Name", "title": "Name", "autoWidth": true },
              /*  { "data": "CreatedBy", "name": "CreatedBy", "title": "CreatedBy", "autoWidth": true },
                { "data": "CreatedOnText", "name": "CreatedOnText", "title": "CreatedOnText", "autoWidth": true },
                { "data": "ModifiedBy", "name": "ModifiedBy", "title": "ModifiedBy", "autoWidth": true },
                { "data": "ModifiedOnText", "name": "ModifiedOnText", "title": "ModifiedOnText", "autoWidth": true },*/
            ]
        });
    },

    showAddEditModal: function (hideModelCallback, id = 0) {
        $("#ModalAddEdit").unbind('hidden.bs.modal');
        $("#ModalAddEdit").on('hidden.bs.modal', function (e) {
            if (hideModelCallback) {
                hideModelCallback(jobIndex.hideModelCallbackData);
                return;
            }
        });

        $('#ModalAddEdit').modal('show');

        $.ajax({
            type: "GET",
            url: "/JobCategory/AddEdit?Id=" + id,
            //data: {
            //    'id': id
            //},
            success: function (data) {
                $("#ModalAddEdit .modal-body").html(data);
            },
            error: function (error) {
                debugger
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
        $.ajax({
            type: "DELETE",
            url: "/JobCategory/Delete?Id="+id,
            success: function (data) {
                common.showAlert(data);
                jobIndex.refresh();
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
        $("#TblJob").dataTable().fnDraw();
    }
}