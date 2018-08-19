using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Seguradora.Util
{
    public class Util
    {
        public static bool ValidarCnpj(string cnpj)
        {
            cnpj = cnpj.Trim();
            cnpj = RemoverPontuacao(cnpj);

            if (cnpj.Length != 14)
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digitoVerificador;
            string cnpjTemporario;
            
            cnpjTemporario = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpjTemporario[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digitoVerificador = resto.ToString();

            cnpjTemporario = cnpjTemporario + digitoVerificador;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpjTemporario[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digitoVerificador = digitoVerificador + resto.ToString();

            return cnpj.EndsWith(digitoVerificador);
        }

        public static bool ValidarCpf(string cpf)
        {
            cpf = cpf.Trim();
            cpf = RemoverPontuacao(cpf);

            if (cpf.Length != 11)
                return false;

            if (Regex.IsMatch(cpf, "([0]{11}|[1]{11}|[2]{11}|[3]{11}|[4]{11}|[5]{11}|[6]{11}|[7]{11}|[8]{11}|[9]{11})"))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string cpfTemporario;
            string digito;
            int soma;
            int resto;
           
            cpfTemporario = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpfTemporario[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            cpfTemporario = cpfTemporario + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpfTemporario[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static string GerarHashMd5(string texto)
        {
            var md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

            var resultado = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                resultado.Append(data[i].ToString("x2"));

            return resultado.ToString();
        }

        public static string RemoverPontuacao(string texto)
        {
            return Regex.Replace(texto, "[./-]+", "");
        }
    }
}