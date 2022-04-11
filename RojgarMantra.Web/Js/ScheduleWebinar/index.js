var ScheduleWebinarIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        ScheduleWebinarIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            ScheduleWebinarIndex.showAddEditModal(ScheduleWebinarIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            ScheduleWebinarIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblScheduleWebinar').DataTable({
            "sAjaxSource": "/ScheduleWebinar/List",
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
                        return "<a href='/ScheduleWebinar/AddEdit?Id=" + row.Id + "'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='ScheduleWebinarIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "Title", "name": "Title", "title": "Title", "autoWidth": true },
                { "data": "PresenterName", "name": "PresenterName", "title": "Presenter Name", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "Date", "name": "Date", "title": "Date", "autoWidth": true },
                { "data": "StartTime", "name": "StartTime", "title": "Start Time", "autoWidth": true },
                { "data": "EndTime", "name": "EndTime", "title": "End Time", "autoWidth": true },
                { "data": "PhysicalVirtual", "name": "PhysicalVirtual", "title": "Physical Or Virtual?", "autoWidth": true },
            ]
        });
    },


    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/ScheduleWebinar/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                ScheduleWebinarIndex.refresh();
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
        $("#TblScheduleWebinar").dataTable().fnDraw();
    }
}