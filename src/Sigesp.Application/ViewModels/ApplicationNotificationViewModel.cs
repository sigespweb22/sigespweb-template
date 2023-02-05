using System;
using System.ComponentModel;

namespace Sigesp.Application.ViewModels
{
    public class ApplicationNotificationViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Escopo da notificacao")]
        public string Scope { get; set; }

        [DisplayName("Usuário remetente")]
        public string SenderUser { get; set; }

        [DisplayName("É lida?")]
        public bool IsRead { get; set; }

        [DisplayName("Título da mensagem")]
        public string MessageTitle { get; set; }

        [DisplayName("Mensagem")]
        public string MessageBody { get; set; }

        [DisplayName("Mensagem label")]
        public string MessageLabel { get; set; }

        [DisplayName("Mensagem label cor")]
        public string MessageLabelColor { get; set; }

        [DisplayName("Data da Mensagem")]
        public string MessageDate { get; set; }

        [DisplayName("ID Usuário")]
        public string UserId { get; set; }

        [DisplayName("ID Unidade")]
        public string TenantId { get; set; }
    }
}