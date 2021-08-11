using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        private WebDriverWait wait;

        public SampleApplicationPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsVisible 
        {
            get
            {
                return Driver.Title.Contains("Ultimate QA");
            }
            internal set 
            {
            } 
        }

        public IWebElement inputName => Driver.FindElement(By.Name("firstname"));

        public IWebElement submitButton => Driver.FindElement(By.Id("submitForm"));

        internal void Goto()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-1/");
            wait.Until(ElementExists(By.XPath("//link[@href='https://ultimateqa.com/wp-content/uploads/2016/04/QALOGO-150x150.png']")));
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            inputName.SendKeys(user.Name);
            submitButton.Click();
            return new UltimateQAHomePage(Driver);
        }


    }
}