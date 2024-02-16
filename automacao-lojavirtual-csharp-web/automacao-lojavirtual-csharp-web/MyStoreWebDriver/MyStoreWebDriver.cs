using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace automacao_lojavirtual_csharp_web.MyStoreWebDriver
{
	public class MyStoreWebDriver
	{
		public IWebDriver driver;
		private String url = "http://www.automationpractice.pl/index.php";

		public void CriarWebDriver()
		{
            //SetEdge();
            SetChrome();
        }

        private void SetEdge()
        {
            try
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                Console.WriteLine("WebDriver iniciado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao carregar o Webdriver do Microsoft Edge: " + e.Message);
            }
        }

        private void SetChrome()
        {
            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                Console.WriteLine("WebDriver iniciado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao carregar o Webdriver do Google Chrome: " + e.Message);
            }
        }

        public IWebDriver getCurrentRunningDriver()
        {
            return driver;
        }

        public void FecharDriverWeb()
        {
            driver.Close();
            Console.WriteLine("WebDriver finalizado com sucesso!");
        }
    }
}