using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using System;
using WebDriverManager.DriverConfigs.Impl;
using System.IO;
using System.Reflection;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = GetChromeDriver();
            Driver.Manage().Window.Maximize();
        } 

        [TestCleanup]
        public void Finalize()
        {
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestMethod]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.Goto();
            Assert.IsTrue(sampleApplicationPage.IsVisible, "Sample application page was not visible.");

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(new TestUser("Rafael", ""));
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA page was not visible.");
        }

        [TestMethod]
        public void PretendTestNumber2()
        {
            var sprint2ApplicationPage = new Sprint2ApplicationPage(Driver);
            
            sprint2ApplicationPage.GoToSprint2();
            Assert.IsTrue(sprint2ApplicationPage.IsVisible, "Sprint 2 page was not visible.");

            var ultimateQAHomePage = sprint2ApplicationPage.FillOutFormAndSubmit(new TestUser("Rafael", "Villalvazo"));
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA page was not visible.");
        }
    }
}
