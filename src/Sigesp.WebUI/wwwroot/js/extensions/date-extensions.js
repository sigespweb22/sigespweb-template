'use strict';

const anoCorrenteByDate = function (date) {
    var data = date;
    var primeiroDiaAnoCompleto = new Date(data.getFullYear(), 0);
    var anoCorrente = primeiroDiaAnoCompleto.getFullYear();

    return anoCorrente;
}

const dateNowToLocaleDateString = function () {
    var today = new Date();
	var dateToLocaleDateString = today.toLocaleDateString("pt-br");

    return dateToLocaleDateString;
}

const firtDayMonth = function () {
    var date = new Date();
    var dateTwo = new Date(), y = date.getFullYear(), m = date.getMonth();
    var firstDay = new Date(y, m, 1);

    return firstDay;
}

const lastDayMonth = function () {
    var date = new Date();
    var dateTwo = new Date(), y = date.getFullYear(), m = date.getMonth();
    var lastDay = new Date(y, m + 1, 0);

    return lastDay;
}

const differenceInDays = function (dataInicio, dataFim) {
    if (dataInicio == null || dataInicio == ""
        || dataFim == null || dataFim == "")
    {
        return "Data início e fim requeridas.";   
    }
     
    var date1 = new Date(dataInicio);
    var date2 = new Date(dataFim);

    var difference_In_Time = date2.getTime() - date1.getTime();
    var difference_In_Days = difference_In_Time / (1000 * 3600 * 24);

    if (isNaN(difference_In_Days)) 
        return 0;
    return difference_In_Days;
}



























// var Factory = function () {
//     this.createEmployee = function (type) {
//         var employee;

//         if (type === "fulltime") {
//             employee = new FullTime();
//         } else if (type === "parttime") {
//             employee = new PartTime();
//         } else if (type === "temporary") {
//             employee = new Temporary();
//         } else if (type === "contractor") {
//             employee = new Contractor();
//         }

//         employee.type = type;

//         employee.say = function () {
//             console.log(this.type + ": rate " + this.hourly + "/hour");
//         }

//         return employee;
//     }
// }

// var FullTime = function () {
//     this.hourly = "$12";
// };

// var PartTime = function () {
//     this.hourly = "$11";
// };

// var Temporary = function () {
//     this.hourly = "$10";
// };

// var Contractor = function () {
//     this.hourly = "$15";
// };

// function run() {

//     var employees = [];
//     var factory = new Factory();

//     employees.push(factory.createEmployee("fulltime"));
//     employees.push(factory.createEmployee("parttime"));
//     employees.push(factory.createEmployee("temporary"));
//     employees.push(factory.createEmployee("contractor"));

//     for (var i = 0, len = employees.length; i < len; i++) {
//         employees[i].say();
//     }
// }

// function createRobot(name) {
//     return {
//         name: name,
//         talk: function () {
//             console.log('My name is ' 
//             + name + ', the robot.');
//         }
//     };
// }

// //Create a robot with name Chitti
// const robo1 = createRobot('Chitti');

// robo1.talk();


// // Create a robot with name Chitti 2.O Upgraded
// const robo2 = createRobot('Chitti 2.O Upgraded');

// robo2.talk();


// // Factory Function creating person
// var Person = function (name, age) {
  
//     // creating person object
//     var person = {};

//     // parameters as keys to this object  
//     person.name = name;
//     person.age = age;

//     // function to greet
//     person.greeting = function () {
//         return (
//             'Hello I am ' + person.name 
//                 + '. I am ' + person.age 
//                 + ' years old. '
//         );
//     };
//     return person;
// };

// var person1 = Person('Abhishek', 20);
// console.log(person1.greeting());

// var person2 = Person('Raj', 25);
// console.log(person2.greeting());