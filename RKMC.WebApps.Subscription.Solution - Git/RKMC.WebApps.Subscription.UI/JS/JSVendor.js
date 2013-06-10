$(document).ready(function () {

    var DisplayVendorDiv = $('#PGetVendorList_DivVendor');
    var DisplayVendorListDiv = $('#PGetVendorList_DivVendorList');


    $('.button').click(function () {
        if ($(this).attr("value") == 'Cancel' && $(this).attr("id") == 'PGetVendor_Cancel') {
            DisplayVendorDiv.hide();
            $('#GreyOut').fadeOut('slow');
        }
    });
});
