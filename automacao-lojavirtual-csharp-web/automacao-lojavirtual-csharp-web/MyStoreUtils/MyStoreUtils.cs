using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace automacao_lojavirtual_csharp_web.MyStoreUtils
{
	public class MyStoreUtils
	{
        private IWebDriver _driver;
        private WebDriverWait wait;

        public MyStoreUtils(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void Clicar(By by)
        {
            try
            {
                SelecionarElemento(by);
                IWebElement elemento = _driver.FindElement(by);
                elemento.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar Clicar no elemento: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Escrever(By by, string texto)
        {
            try
            {
                SelecionarElemento(by);
                IWebElement elemento = _driver.FindElement(by);
                elemento.SendKeys(texto);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar Escrever no elemento: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void SelecionarElemento(By by)
        {
            try
            {
                Thread.Sleep(1500);
                IWebElement elemento = wait.Until(ExpectedConditions.ElementExists(by));
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].style.border=arguments[1]", elemento, "solid 4px red");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar Selecionar o elemento: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void ClicarJS(By by)
        {
            try
            {
                Thread.Sleep(1000);
                IWebElement element = _driver.FindElement(by);
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar Clicar no elemento com Javascript: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void LimparCampoElemento(By by)
        {
            try
            {
                SelecionarElemento(by);
                IWebElement elemento = wait.Until(ExpectedConditions.ElementExists(by));
                elemento.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar Limpar o elemento: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void VerificarElementoVisivel(By by)
        {
            try
            {
                Thread.Sleep(1500);
                EsperaExplicita(by);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao esperar elemento estar visivel: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public bool ElementoExibido(By by)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                return _driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            catch (ElementNotVisibleException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement EsperaExplicita(By by)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Erro ao aguardar se elemento ficara visivel: " + e.Message);
                throw new Exception(e.StackTrace);
            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine("Erro ao aguardar se elemento ficara visivel: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Aguarde(int s)
        {
            Thread.Sleep(s);
        }

        public void EsperaImplicita()
        {
            Thread.Sleep(1000);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void AlterarParaIframe(IWebElement iframe)
        {
            _driver.SwitchTo().Frame(iframe);
        }

        public void SairDoIframe()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public string ObterTextoDoElemento(By by)
        {
            IWebElement elemento = wait.Until(ExpectedConditions.ElementIsVisible(by));
            string txt = elemento.Text;
            return txt;
        }

        public void ValidarTextoDoElemento(By elemento, string texto)
        {
            string txtElement = ObterTextoDoElemento(elemento);
            SelecionarElemento(elemento);

            Console.WriteLine("Texto esperado: " + texto);
            Console.WriteLine("Texto obtido: " + txtElement);

            Assert.That(txtElement, Is.EqualTo(texto));
        }

        public void MoverParaElemento(By by)
        {
            IWebElement elemento = wait.Until(ExpectedConditions.ElementIsVisible(by));
            var element = elemento;
            Actions ac = new Actions(_driver);
            ac.MoveToElement(element);
        }

        public void ScrollDown(int p)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            if (p == 150)
            {
                js.ExecuteScript("window.scrollBy(0,150)", "");
            }
            else if (p == 250)
            {
                js.ExecuteScript("window.scrollBy(0,250)", "");
            }
            else if (p == 350)
            {
                js.ExecuteScript("window.scrollBy(0,350)", "");
            }
            else if (p == 450)
            {
                js.ExecuteScript("window.scrollBy(0,450)", "");
            }
            else if (p == 500)
            {
                js.ExecuteScript("window.scrollBy(0,500)", "");
            }
            else if (p == 600)
            {
                js.ExecuteScript("window.scrollBy(0,600)", "");
            }
            else
            {
                js.ExecuteScript("window.scrollBy(0,300)", "");
            }
            Thread.Sleep(2000);
        }

        public void ScrollUp(int p)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            if (p == 150)
            {
                js.ExecuteScript("window.scrollBy(0,-150)", "");
            }
            else if (p == 250)
            {
                js.ExecuteScript("window.scrollBy(0,-250)", "");
            }
            else if (p == 350)
            {
                js.ExecuteScript("window.scrollBy(0,-350)", "");
            }
            else if (p == 450)
            {
                js.ExecuteScript("window.scrollBy(0,-450)", "");
            }
            else if (p == 500)
            {
                js.ExecuteScript("window.scrollBy(0,-500)", "");
            }
            else if (p == 600)
            {
                js.ExecuteScript("window.scrollBy(0,-600)", "");
            }
            else
            {
                js.ExecuteScript("window.scrollBy(0,-300)", "");
            }
            Thread.Sleep(1500);
        }

        public DateTime PegarDataHoraAtual()
        {
            DateTime dataEntrada = DateTime.Now;
            Console.WriteLine("Data e Hora atual: " + dataEntrada);
            Console.WriteLine("The current date and time: {0:MM-dd-yy H-mm-ss zzz}", dataEntrada);
            return dataEntrada;
        }

        public string GerarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }
    }
}