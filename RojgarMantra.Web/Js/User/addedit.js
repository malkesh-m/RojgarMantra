var userAddEdit = {
    init: function () {
        $('#BtnSave').click(function (e) {
            userAddEdit.save();
        });
    },

    save: function () {
        if (!common.validateForm($("#FrmUserAddEdit")))
            return;

        $.ajax({
            type: "POST",
            url: '/User/AddEdit/' + window.location.search,
            data: common.collectFormData($("#FrmUserAddEdit")),
            success: function (data) {
                common.showAlert(data);

                //var grid = $("#itemGrid").data("kendoGrid");
                //grid.dataSource.read();
                $("#modalAddEdit").modal('hide');

            },
            error: function () {
                common.showErrorAlert();
                //alert('Error');
            },
            beforeSend: function () {
                //showLoader();
            },
            complete: function () {
                //    hideLoader($('#frmTeamUser'));
            }
        });
    }
}