using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject2
{
    public class CartPage
    {
        private IWebDriver driver;


        /// <summary>
        /// Initialize Page
        /// </summary>        
        /// <author>Imran Rarani</author>
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Attempts to check if the Cart List displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsCartListDisplayed()
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//div[@class='cart_list']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Cart List. {e.Message}");
            }
            return isDisplayed;

        }

        /// <summary>
        /// Click on Check Out Button
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public InformationPage ClickOnCheckOut()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@id='checkout']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Checkout Button. {e.Message}");
            }
            return new InformationPage(driver);
        }
    }
}