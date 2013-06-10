var PGetSubscription_FormObject;

$(document).ready(function () {
    //notes:    hide address fields
    $('.addressHidden').hide();

    //notes:    instantiate datepicker for applicable date fields
    $('.datepicker').datepicker();

    if (document.getElementById('txtPerson').value != "") {
        document.getElementById('PGetSubscription_Submit').value = "Save";
    }
    else {
        document.getElementById('PGetSubscription_Submit').value = "Create";
        document.getElementById('rbOffice').checked = true;
    }

    $('#PGetSubscription_Submit').click(function () {
        PGetSubscription_FormObject = $(this).closest("form");
        PGetSubscription_StartProcess();
    });

    $('.rblAddress').click(function () {
        if ($(this).attr("value") == 'Office') {
            document.getElementById('PGetCalendar_DivSubscription').style.height = "450px";
            $('.addressHidden').hide();
            document.getElementById('rbHome').checked = false;
        }
        else {
            document.getElementById('PGetCalendar_DivSubscription').style.height = "600px";
            $('.addressHidden').show();
            document.getElementById('rbOffice').checked = false;
        }
    });

    $('.button').click(function () {
        if ($(this).attr("value") == 'Cancel' && $(this).attr("id") == 'PGetSubscription_Cancel') {
            $('#PGetCalendar_DivSubscription').hide();
            $('#GreyOut').fadeOut('slow');
        }
    });

});

function PGetSubscription_StartProcess() {
    //notes:    do any logic here
    PGetSubscription_ProcessService();
}
function PGetSubscription_ProcessService() {
    //notes:    gray out screen before processing
    //GreyOutScreen();
    //alert('hello world');

    alert(PGetSubscription_FormObject.serializeNoViewState());
    //notes:    serialize form data without viewstate data
    $.ajax({
        url: "http://jake.subscription.com/Services/SubscriptionService.aspx?MethodName=SubmitSubscription",
        type: "POST",
        data: PGetSubscription_FormObject.serializeNoViewState(),
        success: function (StatusResult) {
            // set fields after successful submission (calendar)
            //$('#ReportContent').html(StatusResult);
            alert(StatusResult);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    });
}