var CityIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        CityIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            CityIndex.showAddEditModal(CityIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            CityIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblCity').DataTable({
            "sAjaxSource": "/City/List",
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
                        return "<a href='/City/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='CityIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
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


    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/City/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                CityIndex.refresh();
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
        $("#TblCity").dataTable().fnDraw();
    }
}