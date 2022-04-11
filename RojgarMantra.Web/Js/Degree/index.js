﻿var DegreeIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        DegreeIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            DegreeIndex.showAddEditModal(DegreeIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            DegreeIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblDegree').DataTable({
            "sAjaxSource": "/Degree/List",
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
                        return "<a href='/Degree/AddEdit?Id=" + row.Id + "' title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='DegreeIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
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
            url: "/Degree/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                DegreeIndex.refresh();
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
        $("#TblDegree").dataTable().fnDraw();
    }
}