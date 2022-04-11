var PlacementDriveIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        PlacementDriveIndex.bindGrid();
        $('#BtnAddJob').click(function () {
            PlacementDriveIndex.showAddEditModal(PlacementDriveIndex.refresh, undefined);
        });

        $('#BtnRefresh').click(function () {
            PlacementDriveIndex.refresh();
        });
    },

    bindGrid: function () {
        $('#TblPlacementDrive').DataTable({
            "sAjaxSource": "/PlacementDrive/List",
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
                        return "<a href='/PlacementDrive/AddEdit?Id=" + row.Id + "' title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='PlacementDriveIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "JobTitle", "name": "JobTitle", "title": "Job Title", "autoWidth": true },
                { "data": "PrimaryCoOrdinatorName", "name": "PrimaryCoOrdinatorName", "title": "Primary Co-Ordinator Name", "autoWidth": true },
                { "data": "CoOrdinatorNumber", "name": "CoOrdinatorNumber", "title": "Co-Ordinator Number", "autoWidth": true },
                { "data": "NumberOfVacancies", "name": "NumberOfVacancies", "title": "Number Of Vacancies", "autoWidth": true },
                { "data": "RequiredQualification", "name": "RequiredQualification", "title": "Required Qualification", "autoWidth": true },
                { "data": "JobLocation", "name": "JobLocation", "title": "Job Location", "autoWidth": true },
                {
                    "data": "FromDate", "name": "FromDate", "title": "From Date", "type": "date",
                    "render": function (data) {
                        if (data === null) return "";
                        var pattern = /Date\(([^)]+)\)/;//date format from server side
                        var results = pattern.exec(data);
                        var dt = new Date(parseFloat(results[1]));
                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                    }, "autoWidth": true
                },
                {
                    "data": "ToDate", "name": "ToDate", "title": "To Date", "type": "date",
                    "render": function (data) {
                        if (data === null) return "";
                        var pattern = /Date\(([^)]+)\)/;//date format from server side
                        var results = pattern.exec(data);
                        var dt = new Date(parseFloat(results[1]));
                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                    }, "autoWidth": true
                },
                { "data": "SelectionProcess", "name": "SelectionProcess", "title": "Selection Process", "autoWidth": true },
            ]
        });
    },


    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/PlacementDrive/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                PlacementDriveIndex.refresh();
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
        $("#TblPlacementDrive").dataTable().fnDraw();
    }
}