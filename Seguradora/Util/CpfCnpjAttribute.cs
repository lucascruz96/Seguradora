using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguradora.Util
{
    public class CpfCnpjAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                string cpfCnpj = value.ToString();

                if (cpfCnpj.Length > 11)
                    return Util.ValidarCnpj(cpfCnpj);
                else
                    return Util.ValidarCpf(cpfCnpj);
            }
            catch(Exception)
            {
                return base.IsValid(value);
            }
        }
    }
}