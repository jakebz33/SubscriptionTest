//notes:    jquery function to remove viewstate property when serializing form
$.fn.serializeNoViewState = function () {
    return this.find("input,textarea,select,hidden").not("[type=hidden][name^=__]").serialize();
}