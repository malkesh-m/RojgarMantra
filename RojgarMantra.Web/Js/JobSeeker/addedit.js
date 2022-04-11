
$(function () {
    $("#DateOfBirth").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true
    });
    $("#From").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true
    });

    $("#To").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true
    });
$("#DateOfBirth").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    var dob = $("#DateOfBirth").val();
    dob = dob.split("-");
    var today = new Date();
    todayday = today.getDate();
    todaymonth = today.getMonth() + 1;
    todayyear = today.getFullYear();
    today = today.getTime();
    if (dob[2] > todayyear) {
        $("#DateOfBirth").next('span').text("Date of birth must not be future date.").show();
        return_val = false;
    }
    else if (dob[1] > todaymonth && dob[2] >= todayyear) {
        $("#DateOfBirth").next('span').text("Date of birth must not be future date.").show();
        return_val = false;
    }
    else if (dob[0] > todayday && dob[2] >= todayyear && dob[1] >= todaymonth) {
        $("#DateOfBirth").next('span').text("Date of birth must not be future date.").show();
        return_val = false;
    }
    else {
        $("#DateOfBirth").next('span').hide();
        return_val = false;
    }
});
$("#From").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    var from = $("#From").val();
    from = from.split("-");
    var today = new Date();
    todayday = today.getDate();
    todaymonth = today.getMonth() + 1;
    todayyear = today.getFullYear();
    today = today.getTime();
    if (from[2] > todayyear) {
        $("#From").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else if (from[1] > todaymonth && from[2] >= todayyear) {
        $("#From").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else if (from[0] > todayday && from[2] >= todayyear && from[1] >= todaymonth) {
        $("#From").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else {
        $("#From").next('span').hide();
        return_val = false;
    }
});
$("#To").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    to = $("#To").val();
    to = to.split("-");
    var from = $("#From").val();
    from = from.split("-");
    var today = new Date();
    todayday = today.getDate();
    todaymonth = today.getMonth() + 1;
    todayyear = today.getFullYear();
    today = today.getTime();
    if (to[2] > todayyear) {
        $("#To").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else if (to[1] > todaymonth && to[2] >= todayyear) {
        $("#To").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else if (to[0] > todayday && to[2] >= todayyear && from[1] >= todaymonth) {
        $("#To").next('span').text("From must not be future date.").show();
        return_val = false;
    }
    else if (to[2] < from[2]) {
        $("#To").next('span').text("To must not be less than from date.").show();
        return_val = false;
    }
    else if (to[1] < from[1] && to[2] <= from[2]) {
        $("#To").next('span').text("To must not be less than from date.").show();
        return_val = false;
    }
    else if (to[0] < from[0] && to[2] <= from[2] && to[1] <= from[1]) {
        $("#To").next('span').text("To must not be less than from date.").show();
        return_val = false;
    }
    else {
        $("#To").next('span').hide();
        return_val = false;
    }
});
$("#HSCCompletionYear").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    if ($("#HSCCompletionYear").val() < $("#SSCCompletionYear").val()) {
        $("#HSCCompletionYear").next('span').text("HSC completion year must be greater than SSC.").show();
        return_val = false;
    }
    else {
        $("#HSCCompletionYear").next('span').hide();
        return_val = false;
    }
});
$("#GraduationCompletionYear").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    if ($("#GraduationCompletionYear").val() < $("#HSCCompletionYear").val()) {
        $("#GraduationCompletionYear").next('span').text("Graduation completion year must be greater than HSC.").show();
        return_val = false;
    }
    else {
        $("#GraduationCompletionYear").next('span').hide();
        return_val = false;
    }
});
$("#PostGraduationCompletionYear").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;
    if ($("#PostGraduationCompletionYear").val() < $("#SSCCompletionYear").val()) {
        $("#PostGraduationCompletionYear").next('span').text("Post graduation completion year must be greater than graduation.").show();
        return_val = false;
    }
    else {
        $("#PostGraduationCompletionYear").next('span').hide();
        return_val = false;
    }
});
$("#Resume").change(function () {
    event = event || window.event || event.srcElement;
    var return_val = true;

    var extension = $("#Resume").val().split('.').pop().toLowerCase();
    var validFileExtensions = ['doc', 'docx', 'pdf'];
    if ($.inArray(extension, validFileExtensions) == -1) {
        $("#Resume").next('span').text("Resume must be doc,docx,pdf.").show();
        return_val = false;
    }
    else {
        $("#Resume").next('span').hide();
        return_val = false;
    }
});
        
        });

