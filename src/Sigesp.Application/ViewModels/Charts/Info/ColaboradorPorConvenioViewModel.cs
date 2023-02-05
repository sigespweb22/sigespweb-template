using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Charts.Info
{
    public class ColaboradorPorConvenioViewModel
    {
        public List<string> Label { get; set; }
        public List<int> Data {get; set; }
        public List<string> BackgroundsColor { get; set; }
    }
}