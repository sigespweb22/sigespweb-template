using System;
using System.ComponentModel;

namespace Sigesp.Application.ViewModels
{
    public class FormularioLeituraDicaEscritaDicaViewModelWithoutValidations
    {
        public Guid? Id { get; set; }

        [DisplayName("Dica")]
        public string Dica { get; set; }

        [DisplayName("Ordem")]
        public int Ordem { get; set; }

        public string FormularioLeituraDicaEscritaId { get; set; }
    }
}