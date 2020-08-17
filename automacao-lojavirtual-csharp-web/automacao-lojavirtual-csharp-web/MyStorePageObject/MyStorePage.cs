using System;
using System.Threading;
using OpenQA.Selenium.Remote;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;
using automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorEvidencias;
using automacao_lojavirtual_csharp_web_MyStoreVariabels;
using automacao_lojavirtual_csharp_web_MyStoreUtils;
using automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorPDF;

namespace automacao_lojavirtual_csharp_web_MyStorePageObject
{
    public class MyStorePage : MyStoreWebDriver
    {
        RemoteWebDriver _driver;
        MyStoreVariables myStoreVariables;
        MyStoreUtils myStoreUtils;
        MyStoreGeradorEvidencias myStoreGeradorEvidencias;
        MyStoreGeradorPDF myStoreGeradorPDF;

        public MyStorePage(RemoteWebDriver driver)
        {
            _driver = driver;
            myStoreVariables = new MyStoreVariables(_driver);
            myStoreUtils = new MyStoreUtils(_driver);
            myStoreGeradorEvidencias = new MyStoreGeradorEvidencias(_driver);
            myStoreGeradorPDF = new MyStoreGeradorPDF();
        }

        public void Autenticacao(string email, string senha)
        {
            try
            {
                //myStoreGeradorPDF.CriarDocumentoEmPDF();
                myStoreGeradorEvidencias.CriarPastaEvidencia("Evidencias MyStore_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());

                myStoreUtils.Clicar(myStoreVariables.LblSignIn);
                myStoreUtils.EscreverNoElemento(myStoreVariables.CampoEmailAddress, email);
                myStoreUtils.EscreverNoElemento(myStoreVariables.CampoPassword, senha);
                myStoreGeradorEvidencias.GerarScreenshot("A_Autenticacao_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnSignIn);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtMyAccount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado da classe MyStorePage: " + e.Message);
            }
        }

        public void Deslogar()
        {
            try
            {
                myStoreUtils.Clicar(myStoreVariables.LblSignOut);
                myStoreGeradorEvidencias.GerarScreenshot("W_Deslogar_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.CampoEmailAddress);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.CampoPassword);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.BtnSignIn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado da classe MyStorePage: " + e.Message);
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
                myStoreUtils.Clicar(myStoreVariables.LblWomen);
                myStoreGeradorEvidencias.GerarScreenshot("B_EscolherProduto_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.MoverParaElemento(myStoreVariables.ImgPrintedDress);
                myStoreUtils.Clicar(myStoreVariables.ImgPrintedDress);
                Thread.Sleep(2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa1_AddToCart()
        {
            try
            {
                myStoreUtils.AlterarParaIframe(myStoreVariables.IframePrintedDress);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtPrintedDress);
                myStoreGeradorEvidencias.GerarScreenshot("C_AddToCart_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnAddToCart);
                myStoreUtils.SairDoIframe();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa2_ProductSuccessfullyAddedToYourShoppingCart()
        {
            try
            {
                Thread.Sleep(2);
                myStoreGeradorEvidencias.GerarScreenshot("D_ProductSuccessfullyAddedToYourShoppingCart_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnProceedToCheckout);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa3_ShoppingCartSummary()
        {
            try
            {
                Thread.Sleep(2);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtShoppingCartSummary);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorEvidencias.GerarScreenshot("E_ShoppingCartSummary_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnShoppingCartSummary_ProceedToCheckout);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa4_Adresses()
        {
            try
            {
                Thread.Sleep(2);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtAdresses);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorEvidencias.GerarScreenshot("F_Adresses_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnAdresses_ProceedToCheckout);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa5_Shipping()
        {
            try
            {
                Thread.Sleep(2);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtShipping);
                myStoreUtils.Clicar(myStoreVariables.CheckboxIAgreeToTheTermOfService);
                myStoreGeradorEvidencias.GerarScreenshot("G_Shipping_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnShipping_ProceedToCheckout);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa6_PleaseChooseYourPaymentMethod()
        {
            try
            {
                Thread.Sleep(2);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtPleaseChooseYourPaymentMethod);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorEvidencias.GerarScreenshot("H_PleaseChooseYourPaymentMethod_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.Clicar(myStoreVariables.BtnPayByBankWire);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa7_OrderSummary()
        {
            try
            {
                Thread.Sleep(2);
                myStoreGeradorEvidencias.GerarScreenshot("I_OrderSummary_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtOrderSummary);
                myStoreUtils.Clicar(myStoreVariables.BtnIConfirmMyOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }

        public void Etapa8_OrderConfirmation()
        {
            try
            {
                Thread.Sleep(2);
                myStoreGeradorEvidencias.GerarScreenshot("J_OrderConfirmation_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtOrderConfirmation);
                myStoreUtils.ValidarTextoDoElemento(myStoreVariables.TxtYourOrderOnMyStoreIsComplete, "Your order on My Store is complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado: " + e.Message);
            }
        }
    }
}
