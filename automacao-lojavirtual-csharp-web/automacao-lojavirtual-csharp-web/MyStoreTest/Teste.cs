using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace automacao_lojavirtual_csharp_web.MyStoreTest
{
	public class Teste
	{
        public IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.automationpractice.pl/index.php");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Console.WriteLine("Driver iniciado com sucesso!");
        }

        [Test]
        public void TesteModelo()
        {
            IWebElement el1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("login")));
            el1.Click();

            IWebElement el2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("email")));
            el2.SendKeys("teste@mail.com");

            IWebElement el3 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("passwd")));
            el3.SendKeys("Senh@CSharp");

            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            Console.WriteLine("Driver finalizado com sucesso!");
        }
    }
}

