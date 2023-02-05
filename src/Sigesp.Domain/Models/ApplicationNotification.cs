using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ApplicationNotification : EntityAudit
    {
        public ApplicationNotification(NotificationScopeTypeEnum scope, 
                                        string senderUser, 
                                        bool isRead, string messageTitle,
                                        string messageBody, DateTime messageDate)
        {
            Scope = scope;
            SenderUser = senderUser;
            IsRead = isRead;
            MessageTitle = messageTitle;
            MessageBody = messageBody;
            MessageDate = messageDate;
        }

        //Constructor empty to EFCore
        public ApplicationNotification() { }

        public NotificationScopeTypeEnum Scope { get; set; }
        public string SenderUser { get; set; }
        public bool IsRead { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public string MessageLabel { get; set; }
        public string MessageLabelColor { get; set; }
        public DateTime MessageDate { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}