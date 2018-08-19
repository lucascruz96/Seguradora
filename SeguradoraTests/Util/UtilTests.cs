using NUnit.Framework;
using Seguradora.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora.Util.Tests
{
    [TestFixture()]
    public class UtilTests
    {
        [Test()]
        public void ValidarCnpjInvalidoTest()
        {
            Assert.IsFalse(Util.ValidarCnpj("57.710.303/0001-16"));
            Assert.IsFalse(Util.ValidarCnpj("38057160000141"));
        }

        [Test()]
        public void ValidarCnpjValidoTest()
        {
            Assert.IsTrue(Util.ValidarCnpj("22.482.115/0001-00"));
            Assert.IsTrue(Util.ValidarCnpj("97898633000109"));
        }

        [Test()]
        public void ValidarCpfInvalidoTest()
        {
            Assert.IsFalse(Util.ValidarCpf("999.999.999-99"));
            Assert.IsFalse(Util.ValidarCpf("56199391038"));
        }

        [Test()]
        public void ValidarCpfValidoTest()
        {
            Assert.IsTrue(Util.ValidarCpf("574.789.170-70"));
            Assert.IsTrue(Util.ValidarCpf("94565822059"));
        }

        [Test()]
        public void GerarHashMd5ValidoTest()
        {
            string texto = "Seguradora 123456";
            string esperado = "3fb079792fdd1c1bd59ff56ecae464ef";

            string resultado = Util.GerarHashMd5(texto);

            Assert.AreEqual(esperado, resultado);
        }

        [Test()]
        public void GerarHashMd5InvalidoTest()
        {
            string texto = string.Empty;
            string esperado = string.Empty;

            string resultado = Util.GerarHashMd5(texto);

            Assert.AreNotEqual(esperado, resultado);
        }

        [Test()]
        public void RemoverPontuacaoTest()
        {
            string texto = "536.813.080-56";
            string esperado = "53681308056";

            string resultado = Util.RemoverPontuacao(texto);

            Assert.AreEqual(esperado, resultado);
        }
    }
}