using System;
using automacao_lojavirtual_csharp_web.MyStorePageObject;
using automacao_lojavirtual_csharp_web.MyStoreWebDriver;

namespace automacao_lojavirtual_csharp_web.MyStoreTest
{
	public class MyStoreTest : MyStoreWebDriver.MyStoreWebDriver
	{
        [SetUp]
        public void Setup()
        {
            CriarWebDriver();
        }

        [Test]
        public void TestRealizarCompra()
        {
            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            FecharDriverWeb();
        }
    }
}