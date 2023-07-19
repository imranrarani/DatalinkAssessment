using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class Tests
    {
        IWebDriver driver;
        public TestContext instance;
        private InformationPage informationPage;
        
        public TestContext TestContext
        {
            set
            {
                instance = value;
            }
            get
            {
                return instance;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {

            //Initializing the Chrome Driver
            driver = new ChromeDriver();
         
         }
        [TestCleanup]
        public void TestCleanup()
        {

            //Close the Chrome Driver
            driver.Quit();

        }

        [TestMethod]
        [DoNotParallelize]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","XMLFile2.xml", "LoginDetails", DataAccessMethod.Sequential)]
        public void LoginTest()
        {
            //Get the Test Data
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();           

            

            //Create new object of Login Page 
            var loginPage = new LoginPage(driver, url);

            //Enter Username & Password
            loginPage = loginPage.EnterUsername(username)
                            .EnterPassword(password);

            //Click on Login buttton
            var HomePage = loginPage.ClickLoginButton();

            //Assert the Page
            Assert.IsTrue(HomePage.IsProductsTextDisplayed(), "Not Login Successfully");
        }

        [TestMethod]
        [DoNotParallelize]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "XMLFile2.xml", "LogoutDetails", DataAccessMethod.Sequential)]
        public void LogoutTest()
        {
            //Get the Test Data
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string logoutexpected = TestContext.DataRow["logoutexpected"].ToString();


            //Create new object of Login Page 
            var loginPage = new LoginPage(driver, url);

            //Enter Username & Password
            loginPage = loginPage.EnterUsername(username)
                            .EnterPassword(password);

            //Click on Login buttton
            var HomePage = loginPage.ClickLoginButton();

            //Click on Menu Button
            HomePage.ClickOnMenu();

            //Click on Logout Button
            HomePage.Logout();

            //Assert the Page
            Assert.AreEqual(logoutexpected, driver.Title, "Not Logout Successfully");
        }

        [TestMethod]
        [DoNotParallelize]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "XMLFile2.xml", "HomeDetails", DataAccessMethod.Sequential)]
        public void AddtoAndRemoveCartTest()
        {
            //Get the Test Data
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string product = TestContext.DataRow["product"].ToString();

            //Create new object of Login Page 
            var loginPage = new LoginPage(driver, url);

            //Enter Username & Password
            loginPage = loginPage.EnterUsername(username)
                            .EnterPassword(password);

            //Click on Login buttton
            var HomePage = loginPage.ClickLoginButton();

            //Add to Cart from Home Page
            HomePage = HomePage.AddProduct(product);
            Assert.IsTrue(HomePage.IsShoppingCartBatchDisplayed(), "Shopping cart with product added not displayed");

            //Remove from Home Page
            HomePage = HomePage.RemoveProduct(product);
            Assert.IsFalse(HomePage.IsShoppingCartBatchDisplayed(), "Shopping cart with product added displayed");

        }

        [TestMethod]
        [DoNotParallelize]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "XMLFile2.xml", "InformationDetails", DataAccessMethod.Sequential)]
        public void CheckoutTest()
        {
            //Get the Test Data
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string product = TestContext.DataRow["product"].ToString();
            string firstname = TestContext.DataRow["firstname"].ToString();
            string lastname = TestContext.DataRow["lastname"].ToString();
            string zipcode = TestContext.DataRow["zipcode"].ToString();

            //Create new object of Login Page 
            var loginPage = new LoginPage(driver, url);

            //Enter Username & Password
            loginPage = loginPage.EnterUsername(username)
                            .EnterPassword(password);

            //Click on Login buttton
            var HomePage = loginPage.ClickLoginButton();

            //Add to Cart from Home Page
            HomePage = HomePage.AddProduct(product);
            Assert.IsTrue(HomePage.IsShoppingCartBatchDisplayed(), "Shopping cart with product added not displayed");

            //Go to Cart
            var CartPage = HomePage.ClickOnCart();
            Assert.IsTrue(CartPage.IsCartListDisplayed(), "Cart Page with products are not displayed");

            //Checkout from Cart
            var InformationPage = CartPage.ClickOnCheckOut();
            Assert.IsTrue(InformationPage.IsInformationPageDisplayed(), "Enter Information Detail Page are not displayed");

            //Fill the Information & Click to Continue
            informationPage = InformationPage.EnterFirstName(firstname)
                            .EnterLastName(lastname)
                           .EnterPostalCode(zipcode);
            var CheckOutPage = InformationPage.ClickOnContinue();

            //Validate the Checkout Overview Page & Click to Finish
            Assert.IsTrue(CheckOutPage.IsPaymentInformationDisplayed(), "Product payment information not displayed");
            Assert.IsTrue(CheckOutPage.IsShippingInformationDisplayed(), "Product Shipping information not displayed");

            var ThankYouPage = CheckOutPage.ClickToFinish();

            //Validate the Checkout Completed Successfully
            Assert.IsTrue(ThankYouPage.IsCheckOutCompleteDisplayed(), "Checkout Completed message is not displayed");
            Assert.IsTrue(ThankYouPage.IsBackHomeButtonDisplayed(), "Back Home button is not displayed");

        }

    }
}
