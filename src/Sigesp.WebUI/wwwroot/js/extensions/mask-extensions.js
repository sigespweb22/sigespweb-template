'use strict';

var maskPec = function (input, elem, which) {
    if (which != 8)
    {
        if (input.length == 7)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + "-";

            return $(elem).val(elemNewValue);
        } else if (input.length == 10)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + ".";

            return $(elem).val(elemNewValue);
        } else if (input.length == 15)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + ".";

            return $(elem).val(elemNewValue);
        } else if (input.length == 17)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + ".";

            return $(elem).val(elemNewValue);
        } else if (input.length == 20)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + ".";

            return $(elem).val(elemNewValue);
        }
    }
};

var maskDatePicker = function (input, elem, which) {
    if (which != 8 && which != 13)
    {
        if (input.length == 2)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + "/";

            return $(elem).val(elemNewValue);
        } else if (input.length == 5)
        {
            var elemValueOld = $(elem).val();
            var elemNewValue = elemValueOld + "/";

            return $(elem).val(elemNewValue);
        }
    }
};