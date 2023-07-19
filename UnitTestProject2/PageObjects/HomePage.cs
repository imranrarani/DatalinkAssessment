using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTestProject2
{
    public class HomePage
    {
        private IWebDriver driver;


        /// <summary>
        /// Initialize Page
        /// </summary>        
        /// <author>Imran Rarani</author>
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        /// <summary>
        /// Click on Menu
        /// </summary>
        /// <returns></returns>
        ///  <author>Imran Rarani</author>
        public HomePage ClickOnMenu()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Menu Button. {e.Message}");
            }
            return this;
        }


        /// <summary>
        /// Click on Logout Button
        /// </summary>
        ///  <author>Imran Rarani</author>
        public void Logout()
        {
            try
            {
                driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Logout Button. {e.Message}");
            }
            return;
        }


        /// <summary>
        /// Attempts to check if the Product Text displayed.
        /// </summary>
        /// <returns></returns>
        ///  <author>Imran Rarani</author>
        public bool IsProductsTextDisplayed()
        {
            var isDisplayed = false;
            try
            {
                 isDisplayed = driver.FindElement(By.XPath("//span[@class='title']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Product. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Add the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public HomePage AddProduct(string product)
        {
            try
            {
                IList<IWebElement> products = driver.FindElements(By.XPath("//div[@class='inventory_list']/div/div[2]/div[1]/a"));

                foreach (var p in products)
                {
                   
                    if (product.Equals(p.Text))
                    {
                        driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-onesie']")).Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Add the product. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Click to Remove the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public HomePage RemoveProduct(string product)
        {
            try
            {
                IList<IWebElement> products = driver.FindElements(By.XPath("//div[@class='inventory_list']/div/div[2]/div[1]/a"));

                foreach (var p in products)
                {
                    if (product.Equals(p.Text))
                    {
                        driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-onesie']")).Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Remove the product. {e.Message}");
            }
            return this;
        }

        /// <summary>
        /// Attempts to check if the Shopping Cart Batch displayed.
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public bool IsShoppingCartBatchDisplayed()
        {
            //Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10);

            var isDisplayed = true;
            try
            {                
                isDisplayed = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']")).Displayed;
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to display the Shopping Cart Badge. {e.Message}");
            }
            return isDisplayed;
        }

        /// <summary>
        /// Click on Cart
        /// </summary>
        /// <returns></returns>
        /// <author>Imran Rarani</author>
        public CartPage ClickOnCart()
        {
            try
            {
                driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            }
            catch (Exception e)
            {

                Assert.Fail($"Failed to Click on Cart. {e.Message}");
            }
            return new CartPage(driver);
        }
    }
}