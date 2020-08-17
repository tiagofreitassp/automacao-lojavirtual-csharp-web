using System;
using OpenQA.Selenium.Remote;
using automacao_lojavirtual_chsarp_web_MyStoreWebDriver;

namespace automacao_lojavirtual_chsarp_web_MyStoreUtils_MyStoreGeradorPDF
{
    public class MyStoreGeradorPDF : MyStoreWebDriver
    {
        public MyStoreGeradorPDF()
        {
        }

        public void CriarDocumentoEmPDF()
        {
            // Must have write permissions to the path folder
            //PdfWriter writer = new PdfWriter("/Users/tiago.freitas/Downloads/demo.pdf");
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
