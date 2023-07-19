using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject2
{
    public class InformationPage
    {
        private IWebDriver driver;


        /// <summary>
        /// Initialize Page
        /// </summary>        
        /// <author>Imran Rarani</author>
        public InformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Attempts to check if the Information Page displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsInformationPageDisplayed()
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(By.XPath("//span[@class='title']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Information Page. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Enter the First Name
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public InformationPage EnterFirstName(string firstname)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
                element.Clear();
                element.SendKeys(firstname);

            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to enter First Name: {firstname}. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Enter the Last Name
        /// </summary>
        /// <param name="lastname"></param>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public InformationPage EnterLastName(string lastname)
        {
            try
            {
                IWebElement element =driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
                element.Clear();
                element.SendKeys(lastname);

            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to enter Last Name: {lastname}. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Enter the Postal Code
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public InformationPage EnterPostalCode(string zipcode)
        {
            try
            {
                IWebElement element= driver.FindElement(By.XPath("//input[@placeholder='Zip/Postal Code']"));
                element.Clear();
                element.SendKeys(zipcode);
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to enter Zip Code: {zipcode}. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Click on Continue Button
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public CheckOutPage ClickOnContinue()
        {
            try
            {
                driver.FindElement(By.XPath("//input[@id='continue']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Continue Button. {e.Message}");
            }
            return new CheckOutPage(driver);
        }
    }
}