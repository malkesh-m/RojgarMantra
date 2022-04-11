var jobAddEdit = {
    init: function () {
        $('#BtnSave').click(function (e) {
            jobAddEdit.save();
        });
    },

    save: function () {
        if (!common.validateForm($("#FrmJobAddEdit")))
            return;

        $.ajax({
            type: "POST",
            url: '/JobCategory/AddEdit/' + window.location.search,
            data: common.collectFormData($("#FrmJobAddEdit")),
            success: function (data) {
                common.showAlert(data);
                $("#modalAddEdit").modal('hide');

            },
            error: function () {
                common.showErrorAlert();
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