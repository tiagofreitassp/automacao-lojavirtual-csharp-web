using System;
using System.Net;
using System.Net.Sockets;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenQA.Selenium;

namespace automacao_lojavirtual_csharp_web.MyStoreUtils
{
	public class MyStoreGeradorPDF
	{
        //Dicas sobre o iText
        //https://www.codeguru.com/csharp/.net/net_general/generating-a-pdf-document-using-c-.net-and-itext-7.html

        public IWebDriver _driver;
        public Document document;
        public DirectoryInfo evidencias;
        public int contador;
        public string arqEvidencia;
        public string? status;
        public static string nomeDoUsuario = Environment.UserName;
        public static string downloadsMac = "/Users/" + nomeDoUsuario + "/Downloads/";
        public static string downloadsWindows = "C:/Users/" + nomeDoUsuario + "/Downloads/";
        private string pastaDeImagem = $@"{Directory.GetCurrentDirectory()}/imagens/";
        private string pastaDeEvidencias = $@"{Directory.GetCurrentDirectory()}/evidencias/";

        public MyStoreGeradorPDF(IWebDriver driver, string nomeTeste, string cenario)
        {
            _driver = driver;
            document = new Document();
            contador = 0;
            CriarPastaEvidenciaNoPDF(nomeTeste);
            gerar(nomeTeste);
            addExternalImage();
            addFormatedText("Cenário: " + cenario, FontFactory.HELVETICA, 20, Font.BOLDITALIC,
                    BaseColor.BLUE, Element.ALIGN_CENTER);
            textoInicial();
            document.NewPage();
        }

        public void gerar(string nomeTeste)
        {
            var nomeDoSO = Environment.OSVersion.Platform;
            Console.WriteLine("Sistema Operacional: " + nomeDoSO);

            string so = nomeDoSO.ToString();

            arqEvidencia = pastaDeEvidencias + "/" + nomeTeste + ".pdf";

            PdfWriter.GetInstance(document, new FileStream(arqEvidencia, FileMode.Create));
            document.Open();
            document.Open();
        }

        public void addExternalImage()
        {
            //Image image = Image.GetInstance("/Users/" + nomeDoUsuario + "/Downloads/Csharp.png");
            Image image = Image.GetInstance(pastaDeImagem + "Csharp.png");
            image.ScaleToFit(300f, 300f);
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);
        }

        public void insertPrint()
        {
            ITakesScreenshot ts = (ITakesScreenshot)_driver;
            byte[] imagem = ts.GetScreenshot().AsByteArray;
            Image image = Image.GetInstance(imagem);
            image.ScaleToFit(520f, 520f);
            document.Add(image);
        }

        public void print(string passo)
        {
            if (contador == 2)
            {
                document.NewPage();
                contador = 0;
            }
            addText(passo);
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
                Console.WriteLine("Erro lancado no metodo addText: " + ex.Message);
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
                Console.WriteLine("Erro lancado no metodo addFormatedText: " + ex.Message);
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
                Console.WriteLine("Erro lancaso no metodo addException: " + e.Message);
            }
        }

        public void textoInicial()
        {
            var nomeDoUsuario = Environment.UserName;
            var nomeDoSO = Environment.OSVersion.Platform;
            var nomeDaMaquina = Environment.MachineName;

            addText("Data atual: " + PegarDataFormatada());
            addText("Hora atual: " + PegarHoraFormatada());
            addText("Endereço IP: " + ObterNumeroIP());
            addText("Usuário Atual ou de Rede: " + nomeDoUsuario);
            addText("Nome do computador de execução: " + nomeDaMaquina);
            document.NewPage();
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void finishPdf()
        {
            BaseColor cor = BaseColor.GREEN;
            String resultado = "Evidencias MyStore_" + PegarDataHoraFormatada();
            String novoNome = "Evidencia com novo nome";

            Console.WriteLine("STATUS DO TESTE: " + status);

            if (status.Equals("FAILED") || status.Equals("__FAILED"))
            {
                cor = BaseColor.RED;
                status = "__FAILED";
                resultado = "__FAILED";
                addFormatedText("STATUS DO CENARIO: " + status, FontFactory.TIMES_BOLDITALIC, 16f, 1, cor);
            }
            else
            {
                cor = BaseColor.GREEN;
                status = "__PASSED";
                resultado = "__PASSED";
                addFormatedText("STATUS DO CENARIO: " + status, FontFactory.TIMES_BOLDITALIC, 16f, 1, cor);
            }

            document.Close();
            novoNome = pastaDeEvidencias.Replace(".pdf", resultado +".pdf");

            /*
             * É necessário verificar os metodos para renomear o nome da evidencia PDF inserindo o status junto.
                return new File(arqEvidencia).Replace(new File(novoNome));
                File.Move(pastaDeEvidencias, novoNome);
            */
        }

        public void evidenciaElemento(string passo)
        {
            print(passo);
        }

        public void CriarPastaEvidenciaNoPDF(string nomeDaPastaEvidencia)
        {
            try
            {
                var nomeDoUsuario = Environment.UserName;
                Console.WriteLine("Nome do usuario: " + nomeDoUsuario);

                var nomeDoSO = Environment.OSVersion.Platform;
                Console.WriteLine("Sistema Operacional: " + nomeDoSO);

                string so = nomeDoSO.ToString();

                if (!Directory.Exists(pastaDeEvidencias))
                {
                    //Criar pasta
                    evidencias = Directory.CreateDirectory(pastaDeEvidencias + "/" + nomeDaPastaEvidencia);
                }
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro lancado no metodo CriarPastaEvidenciaNoPDF: " + e.Message);
            }
        }

        public string PegarDataHoraFormatada()
        {
            string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
            return sDataHoraAtual;
        }

        public string PegarDataFormatada()
        {
            string sDataAtual = System.DateTime.Now.ToString("dd-MM-yy");
            Console.WriteLine("Data formatada: " + sDataAtual);
            return sDataAtual;
        }

        public string PegarHoraFormatada()
        {
            string sHoraAtual = System.DateTime.Now.ToString("H-mm-ss");
            Console.WriteLine("Hora formatada: " + sHoraAtual);
            return sHoraAtual;
        }

        public string ObterNumeroIP()
        {
            string getIP = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    getIP = ip.ToString();
                    Console.WriteLine("IP Address = " + ip.ToString());
                }
            }
            return getIP;
        }
    }
}