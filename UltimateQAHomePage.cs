using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {        
        public bool IsVisible 
        {
            get
            {
                try
                {
                    return Image.Displayed;
                }
                catch(NoSuchElementException)
                {
                    return false;
                }
              } 
        }

        public IWebElement Image => Driver.FindElement(By.ClassName("wp-image-216051"));

        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }
    }
}