"use strict";

Object.defineProperty(WebSocket, 'OPEN', { value: 1, });

var connection = new signalR.HubConnectionBuilder().withUrl("/notificacaoHub").build();
 
connection.on("MeuReforcoChannel", function (data) {
    var totalAtualdeMensagens = parseInt(document.getElementById("totalMsgs").textContent)
    document.getElementById("totalMsgs").innerHTML = totalAtualdeMensagens + 1;
     
    function adcElemento () {
        var ul = document.getElementById("notification");
        var li = document.createElement('li');
        li.innerHTML = '<div class="d-flex align-items-center show-child-on-hover">'+
                            '<span class="d-flex flex-column flex-1">'+
                                '<span class="name d-flex align-items-center"><strong><i class="text-warning">'+data.messageTitle+'</i></strong> <span class="badge badge-'+data.messageLabelColor+' fw-n ml-1">'+data.messageLabel+'</span></span>'+
                                '<span class="msg-a fs-sm">'+
                                    ''+data.messageBody+' <a href="servidorestadoreforco/schedule">(Abrir agenda)</a>'+
                                '</span>'+
                                '<span class="fs-nano text-muted mt-1">'+data.messageDate+'</span>'+
                            '</span>'+
                            '<div class="show-on-hover-parent position-absolute pos-right pos-bottom p-3">'+
                                '<a href="#" class="text-muted mr-2" title="Ler"><i class="fal fa-eye"></i></a>'+
                                '<a href="#" class="text-muted" title="Delete"><i class="fal fa-trash-alt"></i></a>'+
                            '</div>'+
                        '</div>'
        
        var primeiraLi = document.getElementById("0");
        ul.insertBefore(li, primeiraLi);
    }
    adcElemento()
});

connection.start()
.then(function () {
    // connection.invoke("JoinGroupAsync", "Teste")
}).catch(function (err) {
    return console.error(err.toString());
});

//https://gist.github.com/alexmagereanu/6751532
// https://learn.microsoft.com/en-us/aspnet/core/signalr/dotnet-client?view=aspnetcore-6.0&tabs=visual-studio#call-hub-methods-from-client
// https://damienbod.com/2017/12/05/sending-direct-messages-using-signalr-with-asp-net-core-and-angular/
// https://balta.io/blog/flutter-signalr