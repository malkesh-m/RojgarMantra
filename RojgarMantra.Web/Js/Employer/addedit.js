var empAddEdit = {
    init: function () {
        debugger
        $("#BtnSave").click(function (e) {
            empAddEdit.save();
        });
    },

    save: function () {
        if (!common.validateForm($("#FrmEmpAddEdit"))) {
            return;
        }

        $.ajax({
            type: "POST",
            url: "/Employer/AddEdit" + window.location.search,
            data: common.collectFormData($("#FrmEmpAddEdit")),
            success: function (data) {
                common.showAlert(data);
               
                window.location.href = "/Employer/Index";
                
            },
            error: function () {
                common.showErrorAlert();
            },
            beforeSend: function () {
            },
            complete: function () {
            }

        });
    }
}