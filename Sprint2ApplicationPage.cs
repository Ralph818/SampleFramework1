using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class Sprint2ApplicationPage : BaseSampleApplicationPage
    {
        private WebDriverWait wait;

        public Sprint2ApplicationPage(IWebDriver driver) :base (driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsVisible
        {
            get
            {
                try
                {
                    return Driver.Title.Contains("Sample Application Lifecycle - Sprint 2 - Ultimate QA");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                
            }
            internal set
            {
            }
        }

        public IWebElement inputName => Driver.FindElement(By.Name("firstname"));

        public IWebElement inputLastName => Driver.FindElement(By.Name("lastname"));

        public IWebElement submitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));

        internal void GoToSprint2()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-2/");
            wait.Until(ElementExists(By.XPath("//link[@href='https://ultimateqa.com/wp-content/uploads/2016/04/QALOGO-150x150.png']")));
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            inputName.SendKeys(user.Name);
            inputLastName.SendKeys(user.LastName);
            submitButton.Click();
            return new UltimateQAHomePage(Driver);
        }
    }
}