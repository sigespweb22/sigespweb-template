'use strict'

let notification = [];

const setNotificationTotal = (value) => {
    if (isNaN(value) || bobcatJS.GeneralExtensions.isNullOrEmptyOrUndefined(value))
    return document.getElementById("totalMsgs").innerHTML = 0
    
    return document.getElementById("totalMsgs").innerHTML = value
}

const updateNotificationTotal = (type, value) => {
    // ** validation required
    if (bobcatJS.GeneralExtensions.isNullOrEmptyOrUndefined(type)) return toastr['error']("Para atualizar o total das notificações é requerido o tipo de atualização. Exe.: SOMAR ou DIMINUIR")
    if (bobcatJS.GeneralExtensions.isNullOrEmptyOrUndefined(value)) return toastr['error']("Para atualizar o total das notificações é requerido o valor de atualização. Exe.: 1, 2, 3, ...")
    
    var tnParsed = parseInt(document.getElementById("totalMsgs").textContent)
    if (type === 'SOMAR')
    {
        return document.getElementById("totalMsgs").textContent = tnParsed + value
    } else if (type === 'DIMINUIR') {
        return document.getElementById("totalMsgs").textContent = tnParsed - value
    } else {
        return toastr['error']("Tipo informado é inválido.")
    }
}

const removeNotification = (elemId) => {
    document.getElementById(elemId).remove()
    updateNotificationTotal('DIMINUIR', 1)
}

const deleteNotification = (id, index) => {
    if (bobcatJS.GeneralExtensions.isNullOrEmptyOrUndefined(id)) return toastr['error']("Id requerido.")

    bobcatJS
        .NotificationStoreService
        .deleteAsync(id)
        .then((response) => {
            if (response.status === 204) return removeNotification(index)
            if (response.status === 404) return toastr['error']("Notificação não encontrada.")
        })
        .catch((e) => {
            buildException(e.response.data, index)
        })
}

const readNotification = (id, index) => {
    if (bobcatJS.GeneralExtensions.isNullOrEmptyOrUndefined(id)) return toastr['error']("Id requerido.")

    bobcatJS
        .NotificationStoreService
        .readAsync(id)
        .then((response) => {
            if (response.status === 200) return removeNotification(index)
            if (response.status === 404) return toastr['error']("Notificação não encontrada.")
        })
        .catch((e) => {
            buildException(e.response.data, index)
        })
}

const buildException = (ex, elemIndex) => {
    var father = document.getElementById(elemIndex);

    const children = '<div class="alert alert-danger alert-dismissible fade show" role="alert" style="border: 0; border-radius: 0">'+
                        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'+
                            '<span aria-hidden="true">×</span>'+
                        '</button>'+
                        '<strong>Atenção!</strong> '+ex+''+
                    '</div>';
    var li = document.createElement('li');
    li.innerHTML = children
    father.appendChild(li);
}

// ** build component notifications
const buildNotifications = (values) => {
    if (typeof values === 'undefined') return "Você não possui nenhuma notificação"

    setNotificationTotal(values.length);
    values.forEach((item, index) => {
        var ul = document.getElementById("notification");

        var li = document.createElement('li');
        li.setAttribute('id', index);

        li.innerHTML = '<div class="d-flex align-items-center show-child-on-hover">'+
                            '<span class="d-flex flex-column flex-1">'+
                                '<span class="name d-flex align-items-center"><strong><i class="text-warning">'+item.messageTitle+'</i></strong> <span class="badge badge-'+item.messageLabelColor+' fw-n ml-1">'+item.messageLabel+'</span></span>'+
                                '<span class="msg-a fs-sm">'+
                                    ''+item.messageBody+' <a href="servidorestadoreforco/schedule">(Abrir agenda)</a>'+
                                '</span>'+
                                '<span class="fs-nano text-muted mt-1">'+item.messageDate+'</span>'+
                            '</span>'+
                            '<div class="show-on-hover-parent position-absolute pos-right pos-bottom p-3">'+
                                '<a onclick="readNotification(\''+item.id+'\', \''+index+'\')" class="text-muted mr-2" title="Ler"><i class="fal fa-eye"></i></a>'+
                                '<a onclick="deleteNotification(\''+item.id+'\', \''+index+'\')" class="text-muted" title="Delete"><i class="fal fa-trash-alt"></i></a>'+
                            '</div>'+
                        '</div>'
        ul.appendChild(li);
    })
}

// ** get and set notificacoes
const setNotifications = () => {
    bobcatJS
        .NotificationStoreService
        .listaAsync()
        .then((response) => {
            setNotificationTotal(response.length)
            if (!response) return "Nenhuma notificação encontrada."

            notification = response.data
            buildNotifications(notification)
        })
        .catch((e) => {
            if (e.status === 400) return toastr['error'](e.responseText)
            if (e.status === 500) return toastr['error'](e.responseText.title)

            return toastr['error'](e)
        })
}