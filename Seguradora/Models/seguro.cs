//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seguradora.Models
{
    using Seguradora.Util;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class seguro
    {
        public long IdSeguro { get; set; }

        [Display(Name = "Cpf/Cnpj")]
        [Required(ErrorMessage = "Informe o cpf ou cnpj do cliente.", AllowEmptyStrings = false)]
        [CpfCnpj(ErrorMessage = "Cpf/Cnpj inv�lido.")]
        public string CpfCnpjCliente { get; set; }

        [Display(Name = "Tipo Seguro")]
        [Required(ErrorMessage = "Informe o tipo de seguro.", AllowEmptyStrings = false)]
        public long TipoSeguro { get; set; }

        [Display(Name = "Objeto")]
        [Required(ErrorMessage = "Informe o objeto do seguro.", AllowEmptyStrings = false)]
        public string Objeto { get; set; }
    }
}
