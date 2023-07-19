using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject2
{
    public class ThankYouPage
    {
        private IWebDriver driver;

        /// <summary>
        /// Initialize Page
        /// </summary>        
        /// <author>Imran Rarani</author>
        public ThankYouPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Attempts to check if the Check Out Complete displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsCheckOutCompleteDisplayed()
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//span[@class='title']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the CheckOut Completed. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Attempts to check if the Back Home Button displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsBackHomeButtonDisplayed()
        {

            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//button[@id='back-to-products']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Back Home Button. {e.Message}");
            }
            return isDisplayed;
        }
    }
}