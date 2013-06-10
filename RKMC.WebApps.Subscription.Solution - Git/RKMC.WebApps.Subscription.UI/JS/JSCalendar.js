$(document).ready(function () {

    var DisplaySubscriptionDiv = $('#PGetCalendar_DivSubscription');

//    DisplaySubscriptionDiv.load('Process/PGetSubscription.aspx');

    $('.calendarVendor').click(function () {
        var subscriptionID = $(this).attr("value");
        DisplaySubscriptionDiv.load('Process/PGetSubscription.aspx?SubscriptionID=' + subscriptionID);

        OpenPopup();
    });
});
function OpenPopup() {
    $('#GreyOut').fadeTo('slow', .8, function () {
        $('#PGetCalendar_DivSubscription').fadeIn('slow', function () {
            $('#txtPerson').focus();
        })
    });
}