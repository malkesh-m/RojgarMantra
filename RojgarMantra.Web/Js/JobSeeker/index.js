var jobSeekerIndex = {
    hideModelCallbackData: undefined,

    init: function () {
        jobSeekerIndex.bindGrid();
        $("#BtnAddJobSeeker").click(function () {
            jobSeekerIndex.showAddEditModal(jobSeekerIndex.refresh, undefined);
        });
        $("#BtnRefresh").click(function () {
            jobSeekerIndex.refresh();
        });
    },

    bindGrid: function () {
        $("#TblJobSeeker").DataTable({
            "sAjaxSource": "/JobSeeker/List",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, "asc"]],
            "language": {
                "emptyTable": "No Record Found.",
                "processing": '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
            },
            "columns": [
                {
                    "data": null, "name": "Action", "title": "Action", "orderable": false, "autoWidth": true,
                    "render": function (data, type, row) {
                        return "<a href='/JobSeeker/AddEdit?Id=" + row.Id +"'  title='Edit'><i class='si si-pencil text-primary mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Edit'></i></a> &nbsp <a href='#' onclick='jobSeekerIndex.delete(\"" + row.Id + "\")'" + row.Id + "' title='Delete'><i class='si si-trash text-danger mr-2' data-toggle='tooltip' title='' data-placement='top' data-original-title='Delete'></i></a>"
                    }
                },
                { "data": "FirstName", "name": "FirstName", "title": "First Name", "autoWidth": true },
                { "data": "LastName", "name": "LastName", "title": "Last Name", "autoWidth": true },
                { "data": "Email", "name": "Email", "title": "Email", "autoWidth": true },
                { "data": "ContactNumber", "name": "ContactNumber", "title": "Contact Number", "autoWidth": true },
              //  { "data": "Gender", "name": "Gender", "title": "Gender", "autoWidth": true },
                { "data": "CurrentAddress", "name": "CurrentAddress", "title": "Current Address", "autoWidth": true },
                { "data": "Skills", "name": "Skills", "title": "Skills", "autoWidth": true },
                { "data": "DegreeName", "name": "DegreeName", "title": "Degree Name", "autoWidth": true },
                { "data": "PostDegreeName", "name": "PostDegreeName", "title": "Post Degree Name", "autoWidth": true },
                { "data": "Experience", "name": "Experience", "title": "Experience", "autoWidth": true },
                { "data": "PrefferredLocation", "name": "PrefferredLocation", "title": "Prefferred Location", "autoWidth": true },
            ]
        });
    },

    showAddEditModal: function (hideModelCallback, id = 0) {
        $("#ModalAddEdit").unbind("hidden.bs.modal");
        $("#ModalAddEdit").on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(jobSeekerIndex.hideModelCallbackData);
                return;
            }
        });

        $('#ModalAddEdit').modal('show');

        $.ajax({
            type: "GET",
            url: "/JobSeeker/AddEdit?Id=" + id,
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
                //
            }
        });
    },

    delete: function (id) {
        $.ajax({
            type: "DELETE",
            url: "/JobSeeker/Delete?Id=" + id,
            success: function (data) {
                common.showAlert(data);
                jobSeekerIndex.refresh();
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
        $("#TblJobSeeker").dataTable().fnDraw();
    }
}