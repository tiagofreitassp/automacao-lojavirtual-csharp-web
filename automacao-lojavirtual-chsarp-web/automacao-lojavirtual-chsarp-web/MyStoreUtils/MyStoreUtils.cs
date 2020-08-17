using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using SeleniumExtras.WaitHelpers;
using automacao_lojavirtual_chsarp_web_MyStoreWebDriver;

namespace automacao_lojavirtual_chsarp_web_MyStoreUtils
{
    public class MyStoreUtils : MyStoreWebDriver
    {
        RemoteWebDriver _driver;

        public MyStoreUtils(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public void Clicar(IWebElement elemento)
        {
            VerificarElementoVisivel(elemento);
            SelecionarElemento(elemento);
            elemento.Click();
        }

        public void EscreverNoElemento(IWebElement elemento, string texto)
        {
            elemento.SendKeys(texto);
            SelecionarElemento(elemento);
        }

        public void LimparCampoElemento(IWebElement elemento)
        {
            elemento.Clear();
        }

        public bool VerificarElementoVisivel(IWebElement elemento)
        {
            return elemento.Displayed;
        }

        public static IWebElement EsperaExplicita(IWebDriver dv, IWebElement el)
        {
            return new OpenQA.Selenium.Support.UI.WebDriverWait(dv, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By)el));
        }

        public void EsperaImplicita()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void AlterarParaIframe(IWebElement iframe)
        {
            _driver.SwitchTo().Frame(iframe);
        }

        public void SairDoIframe()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public string ObterTextoDoElemento(IWebElement elemento)
        {
            string txt = elemento.Text;
            Console.WriteLine("Texto obtido: " + txt);
            return txt;
        }

        public void ValidarTextoDoElemento(IWebElement elemento, string texto)
        {
            string txtElement = ObterTextoDoElemento(elemento);
            SelecionarElemento(elemento);
            Assert.AreEqual(txtElement, texto);
        }

        public void MoverParaElemento(IWebElement elemento)
        {
            var element = elemento;
            Actions ac = new Actions(_driver);
            ac.MoveToElement(element);
            //ac.Perform();
        }

        public void ScrollDown(int p)
        {
            Thread.Sleep(1);
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
            Thread.Sleep(2);
        }

        public void ScrollUp(int p)
        {
            Thread.Sleep(1);
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
            Thread.Sleep(2);
        }

        public void SelecionarElemento(IWebElement elemento)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].style.border=arguments[1]", elemento, "solid 4px red");
        }

        public DateTime PegarDataHoraAtual()
        {
            DateTime dataEntrada = DateTime.Now;
            Console.WriteLine("Data e Hora atual: " + dataEntrada);
            Console.WriteLine("The current date and time: {0:MM-dd-yy H-mm-ss zzz}", dataEntrada);
            return dataEntrada;
        }
    }
}
