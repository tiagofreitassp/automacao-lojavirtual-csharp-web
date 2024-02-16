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
        public MyStoreGeradorPDF evidenciaPDF;
        public MyStoreGeradorEvidencias evidenciaDoc;

        public MyStorePage(IWebDriver driver)
        {
            _driver = driver;
            util = new MyStoreUtils.MyStoreUtils(_driver);
            var = new MyStoreVariables();
            evidenciaPDF = new MyStoreGeradorPDF(_driver, "Evidencias MyStore Web_Realizar compra online_" + util.GerarDataHoraFormatada(), "Realizar compra online");
            evidenciaDoc = new MyStoreGeradorEvidencias(_driver);
        }

        public void SetStatus(string status)
        {
            evidenciaPDF.setStatus(status);
        }

        public void FinishPdf()
        {
            try
            {
                evidenciaPDF.finishPdf();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo FinishPdf: " + e.Message);
            }
        }

        public void Autenticacao(string email, string senha)
        {
            try
            {
                //evidenciaDoc.CriarPastaEvidencia("Evidencias MyStore_" + evidenciaDoc.GerarDataHoraFormatada());

                util.Clicar(By.ClassName(var.LblSignIn));
                util.Escrever(By.Name(var.CampoEmailAddress),email);
                util.Escrever(By.Name(var.CampoPassword),senha);

                //evidenciaDoc.GerarScreenshot("A_Autenticacao");
                evidenciaPDF.evidenciaElemento("Realizando autenticacao");

                util.Clicar(By.Id(var.BtnSignIn));
                util.VerificarElementoVisivel(By.XPath(var.TxtMyAccount));

                evidenciaPDF.evidenciaElemento("Validando tela inicial");
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Autenticacao: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Deslogar()
        {
            try
            {
                util.Clicar(By.ClassName(var.LblSignOut));

                evidenciaPDF.evidenciaElemento("Realizando o logout");
                //evidenciaDoc.GerarScreenshot("W_Deslogar");

                util.VerificarElementoVisivel(By.Id(var.CampoEmailAddress));
                util.VerificarElementoVisivel(By.Id(var.CampoPassword));
                util.VerificarElementoVisivel(By.Id(var.BtnSignIn));

                evidenciaPDF.setStatus("__PASSED");
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Deslogar: " + e.Message);
                throw new Exception(e.StackTrace);
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

                evidenciaPDF.evidenciaElemento("Clicar no produto");
                //evidenciaDoc.GerarScreenshot("B_EscolherProduto");

                util.MoverParaElemento(By.XPath(var.ImgPrintedDress));

                evidenciaPDF.evidenciaElemento("Clicar para visualizar o produto");

                util.Clicar(By.XPath(var.ImgPrintedDress));

                evidenciaPDF.evidenciaElemento("Validando descricao do produto");
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Escolher Produto: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa1_AddToCart()
        {
            try
            {
                //myStoreUtils.AlterarParaIframe(myStoreVariables.IframePrintedDress);

                util.VerificarElementoVisivel(By.XPath(var.TxtPrintedDress));

                VerificarSeProdutoEstaForaDeEstoque();

                evidenciaPDF.evidenciaElemento("Clicar no botao AddToCart");
                //evidenciaDoc.GerarScreenshot("C_AddToCart");

                util.Clicar(By.Id(var.BtnAddToCart));
                //util.SairDoIframe();
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa1_AddToCart: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa2_ProductSuccessfullyAddedToYourShoppingCart()
        {
            try
            {
                evidenciaPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //evidenciaDoc.GerarScreenshot("D_ProductSuccessfullyAddedToYourShoppingCart");

                util.Clicar(By.XPath(var.BtnProceedToCheckout));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa2_ProductSuccessfullyAddedToYourShoppingCart: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa3_ShoppingCartSummary()
        {
            try
            {
                evidenciaPDF.evidenciaElemento("Validando compra na tela Summary");

                util.VerificarElementoVisivel(By.Id(var.TxtShoppingCartSummary));
                util.ScrollDown(450);

                evidenciaPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //evidenciaDoc.GerarScreenshot("E_ShoppingCartSummary");

                util.Clicar(By.XPath(var.BtnShoppingCartSummary_ProceedToCheckout));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa3_ShoppingCartSummary: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa4_Adresses()
        {
            try
            {
                Thread.Sleep(3);

                evidenciaPDF.evidenciaElemento("Validando Adresses");

                if (util.ElementoExibido(By.XPath(var.TxtYourAdresses)))
                {
                    Preencher_Adresses();
                }

                util.ElementoExibido(By.ClassName(var.TxtAdresses));
                util.ScrollDown(450);

                //evidenciaDoc.GerarScreenshot("F_Adresses");
                evidenciaPDF.evidenciaElemento("Clicar no botão ProceedToCheckout");


                util.Clicar(By.Name(var.BtnAdresses_ProceedToCheckout));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa4_Adresses: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa5_Shipping()
        {
            try
            {
                util.SelecionarElemento(By.XPath(var.TxtShipping));

                evidenciaPDF.evidenciaElemento("Clicar no checkbox IAgreeToTheTermOfService");

                util.ScrollDown(150);
                util.ClicarJS(By.XPath(var.CheckboxIAgreeToTheTermOfService));

                evidenciaPDF.evidenciaElemento("Clicar no botao ProceedToCheckout");
                //evidenciaDoc.GerarScreenshot("G_Shipping");

                util.Clicar(By.Name(var.BtnShipping_ProceedToCheckout));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa5_Shipping: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa6_PleaseChooseYourPaymentMethod()
        {
            try
            {
                evidenciaPDF.evidenciaElemento("Validar tela da escolha do pagamento");

                util.VerificarElementoVisivel(By.ClassName(var.TxtPleaseChooseYourPaymentMethod));
                util.ScrollDown(450);

                evidenciaPDF.evidenciaElemento("Clicar no botao PayByBankWire");
                //evidenciaDoc.GerarScreenshot("H_PleaseChooseYourPaymentMethod");

                util.Clicar(By.ClassName(var.BtnPayByBankWire));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa6_PleaseChooseYourPaymentMethod: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa7_OrderSummary()
        {
            try
            {
                evidenciaPDF.evidenciaElemento("Clicar no botao IConfirmMyOrder");
                //evidenciaDoc.GerarScreenshot("I_OrderSummary");

                util.VerificarElementoVisivel(By.ClassName(var.TxtOrderSummary));
                util.Clicar(By.XPath(var.BtnIConfirmMyOrder));
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa7_OrderSummary: " + e.Message);
                throw new Exception(e.StackTrace);
            }
        }

        public void Etapa8_OrderConfirmation()
        {
            try
            {
                evidenciaPDF.evidenciaElemento("Validar a confirmacao da orderm de compra");
                //evidenciaDoc.GerarScreenshot("J_OrderConfirmation");

                util.VerificarElementoVisivel(By.ClassName(var.TxtOrderConfirmation));
                util.ValidarTextoDoElemento(By.XPath(var.TxtYourOrderOnMyStoreIsComplete), "Your order on My Shop is complete.");
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Etapa8_OrderConfirmation: " + e.Message);
                throw new Exception(e.StackTrace);
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

                evidenciaPDF.evidenciaElemento("Preencher endereço");
                //evidenciaDoc.GerarScreenshot("Preencher endereço");
            }
            catch (Exception e)
            {
                evidenciaPDF.setStatus("__FAILED");
                Console.WriteLine("Erro lancado no metodo Preencher_Adresses: " + e.Message);
                throw new Exception(e.StackTrace);
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

