using OpenQA.Selenium;

namespace automacao_lojavirtual_csharp_web;

public class Tests
{
    public IWebDriver driver;

    [SetUp]
    public void Setup()
    {}

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
