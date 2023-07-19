using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject2
{
    public class CheckOutPage
    {
        private IWebDriver driver;

        /// <summary>
        /// Initialize Page
        /// </summary>        
        /// <author>Imran Rarani</author>
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Attempts to check if the Payment Information displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsPaymentInformationDisplayed()
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//div[normalize-space()='Payment Information']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Payment Information. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Attempts to check if the Shipping Information displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsShippingInformationDisplayed()
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//div[normalize-space()='Shipping Information']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Shipping Information. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Click to Finish Button
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public ThankYouPage ClickToFinish()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@id='finish']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Finish Button. {e.Message}");
            }
            return new ThankYouPage(driver);
        }
    }
}