# automacao-lojavirtual-csharp-web
Script para realizar uma compra em uma loja online usando C Sharp, Selenium e NUnit

### Cobertura dos testes:  ###

* Realizar compra online

## Tecnologias:
* [C Sharp](https://docs.microsoft.com/pt-br/dotnet/csharp/)
* [NUnit](https://nunit.org)
* [Selenium](https://www.selenium.dev)
* [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)
* [Marketplace Visual Studio](https://marketplace.visualstudio.com)

## Dependências:
* NUnit
* NUnit3TestAdapter 
* Selenium.Support
* Selenium.WebDriver 
* Selenium.WebDriver.Chrome (Por padrao deixei o Chrome, mas pode baixar os outros plugins dos navegadores)
* Itext (Para criar evidencias em pdf)
* Docx (Para criar evidencias em docx)

## Instruções de execução:

###  - Plataforma
*Importante: Este projeto foi criado no MacOs X usando o Visual Studio 2019 for Mac, nao foi testado no Windows, portanto antes de executar verifique as variaveis com os diretorios para Windows.

###  - Fluxo
*Descricao: Este script ira executar uma compra online, seguindo o fluxo desde a escolha do produto ate a etapa de confirmacao da compra.

###  - Massas
*Descricao: Antes de executar va na classe MyStoreTest/MyStoreTest.cs e verifique se a massa que ja esta la esta funcionando no site, pois o adm do MyStore apaga os emails criados depois de 90 dias.
*Importante: Voce pode criar um cenario para criar login no MyStore, entenda como uma licao de casa para aprender a automacao usando C#

###  - Evidencias
*Importante: As evidencias estao sendo salvas na pasta do Downloads do Mac ou Windows.
*Descricao: E criado uma pasta com as imagens e logo apos elas sao inseridas em um documento do Word ou gerado PDF (Esta etapa esta ocorrendo alguns erros na execucao devido versoes com as versoes recentes do VS 2019 for mac
caso voce percebo que o metodo que cria o documento do Word ou PDF estiverem ausente, e por causa do problema nao ter sido resolvido, mas a criacao da pasta e insercao das imagens estao sem problemas). 

###  - Inicializar a automação
*Descricao: Para executar, abra a classe MyStoreTest/MyStoreTest.cs insira a massa com o email e senha correto. A execucao nao chega a 30 segundos caso nao haja lentidao com a conexao da sua internet. 