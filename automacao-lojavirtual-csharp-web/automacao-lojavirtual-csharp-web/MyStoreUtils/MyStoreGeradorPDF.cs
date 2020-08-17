using System;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;

namespace automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorPDF
{
    public class MyStoreGeradorPDF : MyStoreWebDriver
    {
        public void CriarDocumentoEmPDF()
        {
            string nomeDoUsuario = Environment.UserName;
            string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
            string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";
            string downloads = downloadsMac;

            //// Must have write permissions to the path folder
            //PdfWriter writer = new PdfWriter(downloads + "/demo.pdf");
            //PdfDocument pdf = new PdfDocument(writer);
            //Document document = new Document(pdf);
            //Paragraph header = new Paragraph("HEADER")
            //   .SetTextAlignment(TextAlignment.CENTER)
            //   .SetFontSize(20);

            //document.Add(header);

            //Paragraph subheader = new Paragraph("SUB HEADER")
            //.SetTextAlignment(TextAlignment.CENTER)
            //.SetFontSize(15);
            //document.Add(subheader);

            //document.Close();
        }
    }
}
