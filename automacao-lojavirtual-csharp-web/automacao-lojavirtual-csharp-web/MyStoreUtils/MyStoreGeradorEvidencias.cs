using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using automacao_lojavirtual_csharp_web_MyStoreWebDriver;

namespace automacao_lojavirtual_csharp_web_MyStoreUtils_MyStoreGeradorEvidencias
{
    public class MyStoreGeradorEvidencias : MyStoreWebDriver
    {
		RemoteWebDriver _driver;

		string pastaEvidenciasMac;
		string pastaEvidenciasWindows;
		DirectoryInfo evidencias;

		public MyStoreGeradorEvidencias(RemoteWebDriver driver)
		{
			_driver = driver;
		}

		public void CriarPastaEvidencia(string nomeDaPastaEvidencia)
		{
			pastaEvidenciasMac = "/Users/tiago.freitas/Documents/GitHub/automacao-lojavirtual-csharp-web/automacao-lojavirtual-csharp-web/automacao-lojavirtual-csharp-web/Evidencias/" + nomeDaPastaEvidencia;
			pastaEvidenciasWindows = "/Users/tiago.freitas/Documents/GitHub/automacao-lojavirtual-csharp-web/automacao-lojavirtual-csharp-web/automacao-lojavirtual-csharp-web/Evidencias/" + nomeDaPastaEvidencia;

			var nomeDoSO = Environment.OSVersion.Platform;
			//var nomeDaMaquina = Environment.MachineName;
			//var nomeDoUsuario = Environment.UserName;
			Console.WriteLine("Sistema Operacional: " + nomeDoSO);
			//Console.WriteLine("Nome da maquina: " + nomeDaMaquina);
			//Console.WriteLine("Usuario logado: " + nomeDoUsuario);

			string so = nomeDoSO.ToString();

			if (so == "Unix" || so == "Mac")
			{
				//Verifica se pasta ja existe
				if (!Directory.Exists(pastaEvidenciasMac))
				{
					//Criar pasta
					evidencias = Directory.CreateDirectory(pastaEvidenciasMac);
					Console.WriteLine("Diretorio criado: " + evidencias);
				}
			}
			else if (so == "Windows")
			{
				//Verifica se pasta ja existe
				if (!Directory.Exists(pastaEvidenciasWindows))
				{
					//Criar pasta
					evidencias = Directory.CreateDirectory(pastaEvidenciasWindows);
					Console.WriteLine("Diretorio criado: " + evidencias);
				}
			}
		}

		public void GerarScreenshot(string nomeDaImagem)
		{
			try
			{
				string pastaDasEvidencias = null;
				var nomeDoSO = Environment.OSVersion.Platform;
				Console.WriteLine("Sistema Operacional: " + nomeDoSO);

				string so = nomeDoSO.ToString();
				if (so == "Unix" || so == "Mac")
				{
					pastaDasEvidencias = pastaEvidenciasMac;
					Console.WriteLine("Diretorio Mac/Unix: " + pastaDasEvidencias + "!");
				}
				else if (so == "Windows")
				{
					pastaDasEvidencias = pastaEvidenciasWindows;
					Console.WriteLine("Diretorio Windows: " + pastaDasEvidencias + "!");
				}

				ITakesScreenshot ts = (ITakesScreenshot)_driver;
				Screenshot screenshot = ts.GetScreenshot();
				string pasta = pastaDasEvidencias + "/" + nomeDaImagem + ".png";
				Console.WriteLine("Screenshot salvo no diretorio: " + pasta + "!");
				screenshot.SaveAsFile(pasta, ScreenshotImageFormat.Png);
				Console.WriteLine("Screenshot capturado da imagem " + nomeDaImagem + "!");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Assert.Fail();
			}
		}

		public string GerarDataHoraFormatada()
		{
			string sDataHoraAtual = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
			Console.WriteLine("Data e Hora formatada: " + sDataHoraAtual);
			return sDataHoraAtual;
		}
	}
}
