using System;
using automacao_lojavirtual_chsarp_web_MyStoreWebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace automacao_lojavirtual_chsarp_web_MyStoreVariabels
{
    public class MyStoreVariables : MyStoreWebDriver
    {
        RemoteWebDriver _driver;

        public MyStoreVariables(RemoteWebDriver driver) => _driver = driver;

        public IWebElement LblSignIn => _driver.FindElementByClassName("login");
        public IWebElement LblSignOut => _driver.FindElementByClassName("logout");
        public IWebElement LblDresses => _driver.FindElementByXPath("//li[@class='sfHover']//a[@class='sf-with-ul'][contains(text(),'Dresses')]");
        public IWebElement LblWomen => _driver.FindElementByLinkText("Women");
        public IWebElement LblTShirts => _driver.FindElementByLinkText("T-shirts");

        public IWebElement CampoEmailAddress => _driver.FindElementById("email");
        public IWebElement CampoPassword => _driver.FindElementById("passwd");

        public IWebElement BtnSignIn => _driver.FindElementById("SubmitLogin");
        public IWebElement BtnAddToCart => _driver.FindElementById("add_to_cart");
        public IWebElement BtnProceedToCheckout => _driver.FindElementByXPath("//span[contains(text(),'Proceed to checkout')]");
        public IWebElement BtnContinueShopping => _driver.FindElementByXPath("//span[@title='Continue shopping')]");
        public IWebElement BtnShoppingCartSummary_ProceedToCheckout => _driver.FindElementByXPath("//a[@class='button btn btn-default standard-checkout button-medium']");
        public IWebElement BtnAdresses_ProceedToCheckout => _driver.FindElementByName("processAddress");
        public IWebElement BtnShipping_ProceedToCheckout => _driver.FindElementByName("processCarrier");
        public IWebElement BtnPayByBankWire => _driver.FindElementByClassName("bankwire");
        public IWebElement BtnIConfirmMyOrder => _driver.FindElementByXPath("//span[contains(text(),'I confirm my order')]");

        public IWebElement IconHome => _driver.FindElementByClassName("home");

        public IWebElement ImgPrintedDress => _driver.FindElementByXPath("//img[@title='Printed Dress']");

        public IWebElement IframePrintedDress => _driver.FindElementByClassName("fancybox-iframe");

        public IWebElement CheckboxIAgreeToTheTermOfService => _driver.FindElementById("cgv");

        public IWebElement TxtMyAccount => _driver.FindElementByXPath("//span[@class='navigation_page']");
        public IWebElement TxtAdresses => _driver.FindElementByClassName("page-heading");
        public IWebElement TxtOrderSummary => _driver.FindElementByClassName("page-heading");
        public IWebElement TxtShipping => _driver.FindElementByClassName("page-heading");
        public IWebElement TxtOrderConfirmation => _driver.FindElementByClassName("page-heading");
        public IWebElement TxtYourOrderOnMyStoreIsComplete => _driver.FindElementByXPath("//strong[contains(text(),'Your order on My Store is complete.')]");
        public IWebElement TxtPleaseChooseYourPaymentMethod => _driver.FindElementByClassName("page-heading");
        public IWebElement TxtShoppingCartSummary => _driver.FindElementById("cart_title");
        public IWebElement TxtPrintedDress => _driver.FindElementByXPath("//h1[contains(text(),'Printed Dress')]");
    }
}
