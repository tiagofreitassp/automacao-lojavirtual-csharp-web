using System;
using automacao_lojavirtual_csharp_web_MyStorePageObject;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;
using automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorPDF;
using NUnit.Framework;

namespace automacao_lojavirtual_chsarp_web_MyStoreTest
{
    public class MyStoreTest : MyStoreWebDriver
    {
        public String chrome = "chrome";
        public String firefox = "firefox";
        public String ie = "ie";
        public String edge = "edge";
        public String safari = "safari";

        private MyStorePage myStorePage;
        private MyStoreGeradorPDF myStoreGeradorPDF;

        [SetUp]
        public void Setup()
        {
            CriarDriverWeb(chrome);
        }

        [Test]
        public void TestRealizarCompra()
        {
            myStorePage = new MyStorePage(driver);
            myStorePage.Autenticacao("teste.email.1@mail.com", "abc@12345");
            myStorePage.RealizarCompra();
            myStorePage.Deslogar();
        }

        [TearDown]
        public void TearDown()
        {
            FecharDriverWeb();
        }
    }
}
