var common = {
    showLoader: function($obj) {
        $obj.LoadingOverlay("show", { image: '/img/loader.gif', color: "rgba(0, 0, 0, 0.4)" });
    },

    hideLoader: function($obj) {
        $obj.LoadingOverlay("hide", true);
    },

    showAlert: function(alert) {
        if (!alert.Title) {
            window.swal({
                position: 'top-end',
                type: alert.AlertType.toLowerCase(),
                title: alert.Message,
                showConfirmButton: false,
                timer: 8000,
                toast: true
            });
        } else {
            window.swal({
                position: 'top-end',
                type: alert.AlertType.toLowerCase(),
                title: alert.Title,
                text: alert.Message,
                showConfirmButton: false,
                timer: 8000,
                toast: true
            });
        }
    },

    showErrorAlert: function() {
        var errorAlert = {
            AlertType: 'Error',
            Message: "Error occurred."
        };
        common.showAlert(errorAlert);
    },

    collectFormData: function($form) {
        var data = {};
        $form.serializeArray().map(function (x) { data[x.name] = x.value; });
        debugger
        return data;
    },

    validateForm: function ($form) {
        //$form.validate();
        if ($form.valid()) {
            return true;
        }
        return false;
    }
}