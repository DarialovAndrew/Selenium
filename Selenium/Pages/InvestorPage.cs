using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace SeleniumTesting.Pages
{
    class InvestorPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds
        public InvestorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public string price()
        {
            var price = driver.FindElement(By.XPath("//*[@id=\"nir - ipe - block_4a581869 - 3252 - 4c8b - be43 - 0fbd9ab72d90\"]/div/div/div/div/div[1]/span[4]/text()")).GetAttribute("innerHTML");
            return price;
        } 

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}