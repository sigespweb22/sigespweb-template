'use strict';

var disabledEnabledFieldsForEdit = function (valueDisabled, arrayFields) {
    if (arrayFields != null && arrayFields.length > 0)
    {
        arrayFields.forEach(item => {
            $("#" + item).prop("disabled", valueDisabled);
        });
    }
};