using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum NotificationScopeTypeEnum
    {
        [Display(Name = "Nenhum")]
        NONE = 0,

        [Display(Name = "Aplicação")]
        APPLICATION = 1,

        [Display(Name = "Usuário da aplicação")]
        APPLICATION_USER = 2
    }
}