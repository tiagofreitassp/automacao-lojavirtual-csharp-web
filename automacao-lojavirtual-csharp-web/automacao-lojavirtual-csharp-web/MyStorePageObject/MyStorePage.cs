using System;
using automacao_lojavirtual_csharp_web.MyStoreVariabels;
using automacao_lojavirtual_csharp_web.MyStoreUtils;
using OpenQA.Selenium;

namespace automacao_lojavirtual_csharp_web.MyStorePageObject
{
	public class MyStorePage
	{
        public IWebDriver _driver;
        public MyStoreUtils.MyStoreUtils util;
        public MyStoreVariables var;

        public MyStorePage(IWebDriver driver)
        {
            _driver = driver;
            util = new MyStoreUtils.MyStoreUtils(_driver);
            var = new MyStoreVariables();
        }
        
        public void Autenticacao(string email, string senha)
        {
            try
            {
                util.Clicar(By.ClassName(var.LblSignIn));
                util.Escrever(By.Name(var.CampoEmailAddress),email);
                util.Escrever(By.Name(var.CampoPassword),senha);
                util.Clicar(By.Id(var.BtnSignIn));
                util.VerificarElementoVisivel(By.XPath(var.TxtMyAccount));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Autenticacao: " + e.Message);
            }
        }

        public void Deslogar()
        {
            try
            {
                util.Clicar(By.ClassName(var.LblSignOut));
                util.VerificarElementoVisivel(By.Id(var.CampoEmailAddress));
                util.VerificarElementoVisivel(By.Id(var.CampoPassword));
                util.VerificarElementoVisivel(By.Id(var.BtnSignIn));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Deslogar: " + e.Message);
            }
        }

        public void RealizarCompra()
        {
            EscolherProduto();
            Etapa1_AddToCart();
            Etapa2_ProductSuccessfullyAddedToYourShoppingCart();
            Etapa3_ShoppingCartSummary();
            Etapa4_Adresses();
            Etapa5_Shipping();
            Etapa6_PleaseChooseYourPaymentMethod();
            Etapa7_OrderSummary();
            Etapa8_OrderConfirmation();
        }

        public void EscolherProduto()
        {
            try
            {
                util.Clicar(By.LinkText(var.LblWomen));
                util.MoverParaElemento(By.XPath(var.ImgPrintedDress));
                util.Clicar(By.XPath(var.ImgPrintedDress));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Escolher Produto: " + e.Message);
            }
        }

        public void Etapa1_AddToCart()
        {
            try
            {
                util.VerificarElementoVisivel(By.XPath(var.TxtPrintedDress));

                VerificarSeProdutoEstaForaDeEstoque();

                util.Clicar(By.Id(var.BtnAddToCart));
                //util.SairDoIframe();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa1_AddToCart: " + e.Message);
            }
        }

        public void Etapa2_ProductSuccessfullyAddedToYourShoppingCart()
        {
            try
            {
                util.Clicar(By.XPath(var.BtnProceedToCheckout));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa2_ProductSuccessfullyAddedToYourShoppingCart: " + e.Message);
            }
        }

        public void Etapa3_ShoppingCartSummary()
        {
            try
            {
                util.VerificarElementoVisivel(By.Id(var.TxtShoppingCartSummary));
                util.ScrollDown(450);
                util.Clicar(By.XPath(var.BtnShoppingCartSummary_ProceedToCheckout));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa3_ShoppingCartSummary: " + e.Message);
            }
        }

        public void Etapa4_Adresses()
        {
            try
            {
                Thread.Sleep(3);

                if (util.ElementoExibido(By.XPath(var.TxtYourAdresses)))
                {
                    Preencher_Adresses();
                }

                util.ElementoExibido(By.ClassName(var.TxtAdresses));
                util.ScrollDown(450);
                util.Clicar(By.Name(var.BtnAdresses_ProceedToCheckout));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa4_Adresses: " + e.Message);
            }
        }

        public void Etapa5_Shipping()
        {
            try
            {
                util.SelecionarElemento(By.XPath(var.TxtShipping));
                util.ScrollDown(150);
                util.ClicarJS(By.XPath(var.CheckboxIAgreeToTheTermOfService));
                util.Clicar(By.Name(var.BtnShipping_ProceedToCheckout));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa5_Shipping: " + e.Message);
            }
        }

        public void Etapa6_PleaseChooseYourPaymentMethod()
        {
            try
            {
                util.VerificarElementoVisivel(By.ClassName(var.TxtPleaseChooseYourPaymentMethod));
                util.ScrollDown(450);
                util.Clicar(By.ClassName(var.BtnPayByBankWire));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa6_PleaseChooseYourPaymentMethod: " + e.Message);
            }
        }

        public void Etapa7_OrderSummary()
        {
            try
            {
                util.VerificarElementoVisivel(By.ClassName(var.TxtOrderSummary));
                util.Clicar(By.XPath(var.BtnIConfirmMyOrder));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa7_OrderSummary: " + e.Message);
            }
        }

        public void Etapa8_OrderConfirmation()
        {
            try
            {
                util.VerificarElementoVisivel(By.ClassName(var.TxtOrderConfirmation));
                util.ValidarTextoDoElemento(By.XPath(var.TxtYourOrderOnMyStoreIsComplete), "Your order on My Shop is complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa8_OrderConfirmation: " + e.Message);
            }
        }

        public void Preencher_Adresses()
        {
            try
            {
                util.Clicar(By.Id(var.CampoFirstName));
                util.Clicar(By.Id(var.CampoLastName));
                util.Escrever(By.Id(var.CampoCompany), "Acme LTDA");
                util.Escrever(By.Id(var.CampoAddress), "Apple Park Way");
                util.Escrever(By.Id(var.CampoAddressLine2), "Apple Park");
                util.Escrever(By.Id(var.CampoCity), "Cupertino");

                util.ScrollDown(250);

                util.Clicar(By.Id(var.CampoState));
                util.Clicar(By.Id(var.TxtState_California));
                util.Escrever(By.Id(var.CampoZipPostalCode), "95014");
                util.Escrever(By.Id(var.CampoHomePhone), "(408) 961-1560");
                util.Escrever(By.Id(var.CampoMobilePhone), "(408) 996-1010");
                util.Escrever(By.Id(var.CampoAdditionalInformation), "Null");
                util.Clicar(By.Id(var.CampoPleaseAssignAnAddressTitleForFutureReference));
                util.Clicar(By.Id(var.BtnSave));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Preencher_Adresses: " + e.Message);
            }
        }

        public void VerificarSeProdutoEstaForaDeEstoque()
        {
            ClicarNaCorAzul();
            EscolherTamanhoM();
            EscolherTamanhoL();
        }

        public void ClicarNaCorAzul()
        {
            if (util.ElementoExibido(By.Id(var.TxtThisProductIsNoLongerInStock)))
            {
                util.SelecionarElemento(By.Id(var.TxtThisProductIsNoLongerInStock));

                if (util.ElementoExibido(By.Name(var.TxtProductColor_Blue)))
                {
                    util.Clicar(By.Name(var.TxtProductColor_Blue));
                    util.Aguarde(2000);
                }
            }
        }

        public void ClicarNaCorLaranja()
        {
            if (util.ElementoExibido(By.Id(var.TxtThisProductIsNoLongerInStock)))
            {
                util.SelecionarElemento(By.Id(var.TxtThisProductIsNoLongerInStock));

                if (util.ElementoExibido(By.Name(var.TxtProductColor_Orange)))
                {
                    util.Clicar(By.Name(var.TxtProductColor_Orange));
                    util.Aguarde(2000);
                }
            }
        }

        public void EscolherTamanhoM()
        {
            if (util.ElementoExibido(By.Id(var.TxtThisProductIsNoLongerInStock)))
            {
                util.SelecionarElemento(By.Id(var.TxtThisProductIsNoLongerInStock));
                util.Clicar(By.Id(var.SelectSize));
                util.Clicar(By.XPath(var.OptionSize_M));
            }
        }

        public void EscolherTamanhoL()
        {
            if (util.ElementoExibido(By.Id(var.TxtThisProductIsNoLongerInStock)))
            {
                util.SelecionarElemento(By.Id(var.TxtThisProductIsNoLongerInStock));
                util.Clicar(By.Id(var.SelectSize));
                util.Clicar(By.XPath(var.OptionSize_L));
            }
        }

        public void EscolherTamanhoS()
        {
            if (util.ElementoExibido(By.Id(var.TxtThisProductIsNoLongerInStock)))
            {
                util.SelecionarElemento(By.Id(var.TxtThisProductIsNoLongerInStock));
                util.Clicar(By.Id(var.SelectSize));
                util.Clicar(By.XPath(var.OptionSize_S));
            }
        }
    }
}

