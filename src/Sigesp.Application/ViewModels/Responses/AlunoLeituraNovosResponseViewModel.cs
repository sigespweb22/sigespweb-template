using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Responses
{
    public class AlunoLeituraNovosResponseViewModel
    {
        public AlunoLeituraNovosResponseViewModel()
        {
            errorMessages = new List<string>();
        }

        public bool IsValid { get; private set; }

        private List<string> errorMessages;

        public IEnumerable<string> ErrorMessages
        {
            get { return errorMessages; }
        }

        public void AddErrorMessage(string errorMessage)
        {
            IsValid = false;
            errorMessages.Add(errorMessage);
        }


        public int TotalLeiturasCriadas { get; set; }
        public string LeituraTipo { get; set; }
        public string Cronograma { get; set; }
        public string Galeria { get; set; }
        public string Celas { get; set; }
    }

    public class AlunoLeituraNovosResponse
    {
        public int AlunoLeitorIpen { get; set; }
        public string AlunoLeitorNome { get; set; }
        public string Ocorrencia { get; set; }
    }
}