using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace UnitTestProject2
{
    internal class LoginPage
    {
        private IWebDriver driver;

        /// <summary>
        /// Initialize Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <author>Imran Rarani</author>
        public LoginPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.driver.Url = url;
        }

        /// <summary>
        /// Enter UserName
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        ///  <author>Imran Rarani</author>
        public LoginPage EnterUsername(string username)
        {
            try
            {
                driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys(username);
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to enter username: {username}. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Enter the Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        ///  <author>Imran Rarani</author>
        public LoginPage EnterPassword(string password)
        {
            try
            {
                driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(password);
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to enter password: {password}. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public HomePage ClickLoginButton()
        {
            try
            {
                driver.FindElement(By.XPath("//input[@id='login-button']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Login Button. {e.Message}");
            }
            return new HomePage(driver);
        }
    }
}