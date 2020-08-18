using System;
using System.Collections.Generic;
using System.IO;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorPDF
{
    public class MyStoreGeradorPDF : MyStoreWebDriver
    {
        public void CriarDocumentoDeEvidenciasEmPDF()
        {
            //https://www.codeguru.com/csharp/.net/net_general/generating-a-pdf-document-using-c-.net-and-itext-7.html

            string nomeDoUsuario = Environment.UserName;
            string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
            string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";
            string downloads = downloadsMac;

            //// Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(downloads + "/Evidencias MyStore.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Evidencias MyStore")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);

            Paragraph subheader = new Paragraph("Cenario: Realizar compra online")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Add image
            Image img = new Image(ImageDataFactory
               .Create("/Users/"+ nomeDoUsuario + "/Downloads/Csharp.png"))
                .SetMarginLeft(100)
                .SetMinHeight(300)
                .SetMaxHeight(350)
                .SetMinWidth(400)
                .SetMaxWidth(450)
               .SetTextAlignment(TextAlignment.CENTER);
            document.Add(img);

            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format("page" + i + " of " + n)),
                   559, 806, i, TextAlignment.RIGHT,
                   VerticalAlignment.TOP, 0);
            }

            // Close document
            document.Close();
        }

        public string PegarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }
    }
}
