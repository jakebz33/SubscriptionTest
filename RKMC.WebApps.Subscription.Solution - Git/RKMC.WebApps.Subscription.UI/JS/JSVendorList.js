$(document).ready(function () {

    var DisplayVendorDiv = $('#PGetVendorList_DivVendor');
    var DisplayVendorListDiv = $('#PGetVendorList_DivVendorList');

    $('.button').click(function () {
        if ($(this).attr("value") == 'Edit') {
            var vendorID = $(this).attr("dir");

            DisplayVendorDiv.load('Process/PGetVendor.aspx?VendorID=' + vendorID);

            OpenPopup();          
        }
    });
});
function OpenPopup() {
    $('#GreyOut').fadeTo('slow', .8, function () {
        $('#PGetVendorList_DivVendor').fadeIn('slow', function () {
            $('#txtVendorName').focus();
        })
    });
}