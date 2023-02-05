'use strict';

var isNullOrEmpty = function (input) {
    return input == null || typeof input != "string" || input.trim().length < 1;
};

var limitFor4 = function (input, idField) {
    if (input.length > 4)
    {
        $("#" + idField).val(input.substr(0, 4));
    }
};

var toUpperCaseFormFields = function (inputs) {
    if (inputs == null || inputs.length <= 0 || typeof inputs === 'undefined')
        return "Nenhum valor informado para converter em letra maiúscula";
    
    inputs.forEach(element => {
        var value = element.val;
        if (typeof value !== null && value !== undefined && value != "")
            $(element.id).val(value.toUpperCase());
    });
};

const limitString = (limit, string) => {
    if (string.length > limit)
    {
        let newWithLimit = string.substring(0, limit);
        let newSplited = newWithLimit.slice(0, -3) + '...';
        return newSplited;
    }
    else
    {
        return string;
    }
};

const reverseString = (string) => {
    return string.split("").reverse().join("");
};