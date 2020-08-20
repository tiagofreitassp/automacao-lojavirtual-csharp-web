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
            myStoreGeradorPDF = new MyStoreGeradorPDF(_driver,"Evidencias MyStore Web_"+myStoreUtils.GerarDataHoraFormatada(),"Realizar compra online");
        }

        public void Autenticacao(string email, string senha)
        {
            try
            {
                //myStoreGeradorEvidencias.CriarPastaEvidencia("Evidencias MyStore_" + myStoreGeradorEvidencias.GerarDataHoraFormatada());

                myStoreUtils.Clicar(myStoreVariables.LblSignIn);
                myStoreUtils.EscreverNoElemento(myStoreVariables.CampoEmailAddress, email);
                myStoreUtils.EscreverNoElemento(myStoreVariables.CampoPassword, senha);
                //myStoreGeradorEvidencias.GerarScreenshot("A_Autenticacao");
                myStoreGeradorPDF.evidenciaElemento("Realizando autenticacao");
                myStoreUtils.Clicar(myStoreVariables.BtnSignIn);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtMyAccount);
                myStoreGeradorPDF.evidenciaElemento("Validando tela inicial");
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
                myStoreUtils.Clicar(myStoreVariables.LblSignOut);
                myStoreGeradorPDF.evidenciaElemento("Realizando o logout");
                //myStoreGeradorEvidencias.GerarScreenshot("W_Deslogar");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.CampoEmailAddress);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.CampoPassword);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.BtnSignIn);
                myStoreGeradorPDF.finishPdf();
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
                myStoreUtils.Clicar(myStoreVariables.LblWomen);
                myStoreGeradorPDF.evidenciaElemento("Clicar no produto");
                //myStoreGeradorEvidencias.GerarScreenshot("B_EscolherProduto");
                myStoreUtils.MoverParaElemento(myStoreVariables.ImgPrintedDress);
                myStoreGeradorPDF.evidenciaElemento("Clicar para visualizar o produto");
                myStoreUtils.Clicar(myStoreVariables.ImgPrintedDress);
                myStoreGeradorPDF.evidenciaElemento("Validando descricao do produto");
                Thread.Sleep(2);
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
                myStoreUtils.AlterarParaIframe(myStoreVariables.IframePrintedDress);
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtPrintedDress);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao AddToCart");
                //myStoreGeradorEvidencias.GerarScreenshot("C_AddToCart");
                myStoreUtils.Clicar(myStoreVariables.BtnAddToCart);
                myStoreUtils.SairDoIframe();
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //myStoreGeradorEvidencias.GerarScreenshot("D_ProductSuccessfullyAddedToYourShoppingCart");
                myStoreUtils.Clicar(myStoreVariables.BtnProceedToCheckout);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Validando compra na tela Summary");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtShoppingCartSummary);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //myStoreGeradorEvidencias.GerarScreenshot("E_ShoppingCartSummary");
                myStoreUtils.Clicar(myStoreVariables.BtnShoppingCartSummary_ProceedToCheckout);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Validando Adresses");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtAdresses);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //myStoreGeradorEvidencias.GerarScreenshot("F_Adresses");
                myStoreUtils.Clicar(myStoreVariables.BtnAdresses_ProceedToCheckout);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Clicar no checkbox IAgreeToTheTermOfService");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtShipping);
                myStoreUtils.Clicar(myStoreVariables.CheckboxIAgreeToTheTermOfService);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //myStoreGeradorEvidencias.GerarScreenshot("G_Shipping");
                myStoreUtils.Clicar(myStoreVariables.BtnShipping_ProceedToCheckout);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Validar tela da escolha do pagamento");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtPleaseChooseYourPaymentMethod);
                myStoreUtils.ScrollDown(450);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao PayByBankWire");
                //myStoreGeradorEvidencias.GerarScreenshot("H_PleaseChooseYourPaymentMethod");
                myStoreUtils.Clicar(myStoreVariables.BtnPayByBankWire);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Clicar no botao IConfirmMyOrder");
                //myStoreGeradorEvidencias.GerarScreenshot("I_OrderSummary");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtOrderSummary);
                myStoreUtils.Clicar(myStoreVariables.BtnIConfirmMyOrder);
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
                Thread.Sleep(2);
                myStoreGeradorPDF.evidenciaElemento("Validar a confirmacao da orderm de compra");
                //myStoreGeradorEvidencias.GerarScreenshot("J_OrderConfirmation");
                myStoreUtils.VerificarElementoVisivel(myStoreVariables.TxtOrderConfirmation);
                myStoreUtils.ValidarTextoDoElemento(myStoreVariables.TxtYourOrderOnMyStoreIsComplete, "Your order on My Store is complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo Etapa8_OrderConfirmation: " + e.Message);
            }
        }
    }
}
