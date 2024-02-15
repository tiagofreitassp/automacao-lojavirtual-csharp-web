using System;
using automacao_lojavirtual_csharp_web.MyStorePageObject;
using automacao_lojavirtual_csharp_web.MyStoreWebDriver;

namespace automacao_lojavirtual_csharp_web.MyStoreTest
{
	public class MyStoreTest : MyStoreWebDriver.MyStoreWebDriver
	{
        private MyStorePage? page;

        [SetUp]
        public void Setup()
        {
            CriarWebDriver();
        }

        [Test]
        public void TestRealizarCompra()
        {
            page = new MyStorePage(getCurrentRunningDriver());
            page.Autenticacao("teste.email.1@mail.com", "abc@12345");
            page.RealizarCompra();
            page.Deslogar();
        }

        [TearDown]
        public void TearDown()
        {
            FecharDriverWeb();
        }
    }
}