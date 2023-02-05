'use strict';

var transformObjArrayFieldBoolBackToFront = function(arrayObj) {
    for (var i = 0; i < arrayObj.length; i++) {
        for (var prop in arrayObj[i]) {
            if (typeof(arrayObj[i][prop]) == 'boolean') {
                if (prop == "isDeleted")
                {
                    arrayObj[i][prop] = arrayObj[i][prop] ? 'NÃO' : 'SIM';
                } else {
                    arrayObj[i][prop] = arrayObj[i][prop] ? 'SIM' : 'NÃO';
                }
            }
        }
    };

    return arrayObj;

};

var transformObjFieldBoolFrontToBack = function(obj) {
    for (var prop in obj) {
        if (prop == 'isDeleted')
        {
            obj[prop] = obj[prop] == 'SIM' ? false : true;
        } else {
            obj[prop] = obj[prop] == 'SIM' ? true : obj[prop] == 'NÃO' ? false : obj[prop];
        }
        
    }
    
    return obj;
};