using System;
using System.Collections.Generic;
using System.IO;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorPDF
{
    public class MyStoreGeradorPDF : MyStoreWebDriver
    {
        public RemoteWebDriver _driver;
        public Document document;
        public int contador;
        public string cenario;
        public string arqEvidencia;

        public static string nomeDoUsuario = Environment.UserName;
        public static string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
        public static string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";
        public static string downloads = downloadsMac + "Evidencias MyStore WebSite";

        public MyStoreGeradorPDF(RemoteWebDriver driver, string nomeTeste)
        {
            _driver = driver;
            document = new Document();
            contador = 0;
            gerar(nomeTeste);
            addExternalImage();
            addFormatedText("Cenário: "+nomeTeste, FontFactory.HELVETICA, 20, Font.BOLDITALIC,
                    BaseColor.BLUE, Element.ALIGN_CENTER);
            textoInicial();
            document.NewPage();
        }

        public void CriarDocumentoDeEvidenciasEmPDF()
        {
            //https://www.codeguru.com/csharp/.net/net_general/generating-a-pdf-document-using-c-.net-and-itext-7.html

            //string nomeDoUsuario = Environment.UserName;
            //string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
            //string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";
            //string downloads = downloadsMac;

            //// Must have write permissions to the path folder
            //PdfWriter writer = new PdfWriter(downloads + "/Evidencias MyStore.pdf");
            //PdfDocument pdf = new PdfDocument(writer);
            //Document document = new Document(pdf);
            //Paragraph header = new Paragraph("Evidencias MyStore")
            //   .SetTextAlignment(TextAlignment.CENTER)
            //   .SetFontSize(20);

            //document.Add(header);

            //Paragraph subheader = new Paragraph("Cenario: Realizar compra online")
            //.SetTextAlignment(TextAlignment.CENTER)
            //.SetFontSize(15);
            //document.Add(subheader);

            //// Line separator
            //LineSeparator ls = new LineSeparator(new SolidLine());
            //document.Add(ls);

            //// Add image
            //Image img = new Image(ImageDataFactory
            //   .Create("/Users/" + nomeDoUsuario + "/Downloads/Csharp.png"))
            //    .SetMarginLeft(100)
            //    .SetMinHeight(300)
            //    .SetMaxHeight(350)
            //    .SetMinWidth(400)
            //    .SetMaxWidth(450)
            //   .SetTextAlignment(TextAlignment.CENTER);
            //document.Add(img);

            //// Page numbers
            //int n = pdf.GetNumberOfPages();
            //for (int i = 1; i <= n; i++)
            //{
            //    document.ShowTextAligned(new Paragraph(String
            //       .Format("page" + i + " of " + n)),
            //       559, 806, i, TextAlignment.RIGHT,
            //       VerticalAlignment.TOP, 0);
            //}

            //// Close document
            //document.Close();
        }

        public string PegarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }

        public void gerar(string nomeTeste)
        {
            arqEvidencia = downloads+"/"+nomeTeste+".pdf";
            PdfWriter.GetInstance(document, new FileStream(arqEvidencia, FileMode.Create));
            document.Open();
            document.Open();
        }

        public void addExternalImage()
        {
            Image image = Image.GetInstance("/Users/" + nomeDoUsuario + "/Downloads/Csharp.png");
            image.ScaleToFit(320f, 320f);
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);
        }

        public void insertPrint()
        {
            ITakesScreenshot ts = (ITakesScreenshot)_driver;
            byte[] imagem = ts.GetScreenshot().AsByteArray;
            Image image = Image.GetInstance(imagem);
            image.ScaleToFit(520f,520f);
            document.Add(image);
        }

        public void print(string passo)
        {
            if (contador == 2)
            {
                document.NewPage();
                contador = 0;
            }
            addText("Passo C Sharp");
            insertPrint();
            contador++;
        }

        public void addText(String text)
        {
            try
            {
                document.Add(new Paragraph(text));
            }
            catch (DocumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addFormatedText(String text, String nameFont, float size, int style, BaseColor color, int align)
        {
            try
            {
                Font font = FontFactory.GetFont(nameFont, size, style, color);
                Paragraph paragraph = new Paragraph(text, font);
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(paragraph);
            }
            catch (DocumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void addFormatedText(String text, String nameFont, float size, int style, BaseColor color)
        {
            addFormatedText(text, nameFont, size, style, color, 0);
        }

        public void addFalhaDeValidacao(String text)
        {
            addFormatedText(text, FontFactory.HELVETICA_BOLD, 15f, 1, BaseColor.RED);
        }

        public void addException(Exception ex, String passo)
        {
            try
            {
                addFormatedText("Foi lançada uma exceção durante a execução do passo: " + passo, FontFactory.COURIER_BOLD, 16f,
                        1, BaseColor.RED);
                print("---------ScreenShoot do passo---------");
                StringWriter sw = new StringWriter();
                //PrintWriter pw = new PrintWriter(sw);
                //ex.printStackTrace(pw);
                addFormatedText(sw.ToString(), FontFactory.HELVETICA, 5f, 1, BaseColor.RED);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void textoInicial()
        {
            addText("Data atual: ");
            addText("Hora atual: ");
            addText("Endereço IP: ");
            addText("Usuário Atual ou de rede: ");
            addText("Nome do computador de execução: ");
            document.NewPage();
        }

        public void finishPdf()
        {
            BaseColor cor = BaseColor.GREEN;
            String resultado = "Executado";
            String novoNome = "Evidencia com novo nome";
            //if (cenario.getStatus().toString().equals("FAILED"))
            //{
            //    cor = BaseColor.RED;
            //    resultado = "__FAILED";
            //}
            //else
            //{
            //    resultado = "__PASSED";
            //}
            //addFormatedText("STATUS DO CENARIO: " + cenario.getStatus(), FontFactory.TIMES_BOLDITALIC, 16f, 1, cor);
            document.Close();
            novoNome = arqEvidencia.Replace(".pdf", resultado + ".pdf");
            //return new File(arqEvidencia).Replace(new File(novoNome));
            File.Move(arqEvidencia, novoNome);
        }

        public void evidenciaElemento()
        {
            print("Passos");
        }
    }
}
