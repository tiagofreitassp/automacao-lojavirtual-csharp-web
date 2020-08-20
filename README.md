# automacao-lojavirtual-csharp-web
Script para realizar uma compra em uma loja online usando C Sharp, Selenium, iText e NUnit. Criado no Visual Studio 2019.

### Cobertura dos testes:  ###

* Realizar compra online

## Tecnologias:
* [C Sharp](https://docs.microsoft.com/pt-br/dotnet/csharp/)
* [NUnit](https://nunit.org)
* [Selenium](https://www.selenium.dev)
* [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)
* [Marketplace Visual Studio](https://marketplace.visualstudio.com)
* [iText](https://itextpdf.com/en)

## Dependências:
* NUnit
* NUnit3TestAdapter 
* Selenium.Support
* Selenium.WebDriver 
* Selenium.WebDriver.Chrome (Por padrao deixei o Chrome, mas pode baixar os outros plugins dos navegadores)
* iTextSharp (Para criar evidencias em pdf)
* Docx (Para criar evidencias em docx)

## Instruções de execução:

###  - Plataforma
*Importante: Este projeto foi criado no MacOs X usando o Visual Studio 2019 for Mac, nao foi testado no Windows, portanto antes de executar verifique as variaveis com os diretorios para Windows.

###  - Fluxo
*Descricao: Este script ira executar uma compra online, seguindo o fluxo desde a escolha do produto ate a etapa de confirmacao da compra.

###  - Massas
*Descricao: Antes de executar va na classe MyStoreTest/MyStoreTest.cs e verifique se a massa que ja esta la esta funcionando no site, pois o adm do MyStore apaga os emails criados depois de 90 dias.

*Importante: Voce pode criar um cenario para criar login no MyStore, entenda como uma licao de casa para aprender a automacao usando C#.

###  - Evidencias
*Importante: As evidencias estao sendo salvas na pasta do Downloads do Mac ou Windows.

*Descricao: Ha duas classes em MyStoreUtils para gerar evidencias. A classe MyStoreGeradorEvidencias.cs cria uma pasta em Downloads do Mac ou Windows e insere as imagens, para adicionar as imagens em um documento tipo docx, recomendo usar o DocX, nao coloquei no projeto pois em pdf achei mais em conta devido a rapidez na execucao. A outra classe MyStoreGeradorPDF.cs tira os screenshots e adiciona-os dentro de um documento em pdf e tambem salva-o dentro de Downloads do Mac ou Windows.

###  - Inicializar a automação
*Descricao: Para executar, abra a classe MyStoreTest/MyStoreTest.cs insira a massa com o email e senha correto. A execucao nao chega a 30 segundos caso nao haja lentidao com a conexao da sua internet. 