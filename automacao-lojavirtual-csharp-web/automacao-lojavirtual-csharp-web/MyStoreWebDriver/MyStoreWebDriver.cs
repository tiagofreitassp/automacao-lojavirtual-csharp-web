using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace automacao_lojavirtual_csharp_web_MyStoreWebDriver
{
    public class MyStoreWebDriver
    {
        public RemoteWebDriver driver;
        public String url = "http://automationpractice.com/index.php?";

        public void CriarDriverWeb(string navegador)
        {
            try
            {
                if (navegador.Equals("chrome"))
                {
                    driver = new ChromeDriver();
                    DadosNavegador();
                }
                else if (navegador.Equals("firefox"))
                {
                    driver = new FirefoxDriver();
                    DadosNavegador();
                }
                else if (navegador.Equals("ie"))
                {
                    driver = new InternetExplorerDriver();
                    DadosNavegador();
                }
                else if (navegador.Equals("edge"))
                {
                    driver = new EdgeDriver();
                    DadosNavegador();
                }
                else if (navegador.Equals("safari"))
                {
                    driver = new SafariDriver();
                    DadosNavegador();
                }
                else
                {
                    driver = new ChromeDriver();
                    DadosNavegador();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao carregar o driver do " +
                    "navegador" + navegador + "! " + e.Message);
                Assert.Fail();
            }
        }

        public void DadosNavegador()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            Console.WriteLine("Driver iniciado com sucesso!");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void FecharDriverWeb()
        {
            driver.Quit();
            Console.WriteLine("Driver finalizado com sucesso!");
        }
    }
}
