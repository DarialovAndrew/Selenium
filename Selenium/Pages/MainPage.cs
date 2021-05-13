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
    class MainPage
    {

        String test_url = "https://www.epam.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/our-work']")]
        [CacheLookup]
        private IWebElement learnMore;

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[3]/div")]
        [CacheLookup]
        private IWebElement searchIcon;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_form_search']")]
        [CacheLookup]
        private IWebElement searchPanel;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://careers.epam-czech.cz/']")]
        [CacheLookup]
        private IWebElement czechLang;

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[2]/div")]
        [CacheLookup]
        private IWebElement languagesIcon;

        [FindsBy(How = How.XPath, Using = "//a[@href='/about/investors']")]
        [CacheLookup]
        private IWebElement investors;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.telescopeai.com/']")]
        [CacheLookup]
        private IWebElement telescope;

        [FindsBy(How = How.XPath, Using = "//a[@href='/open-source']")]
        [CacheLookup]
        private IWebElement openSource;

        [FindsBy(How = How.XPath, Using = "//a[@href='/privacy-policy']")]
        [CacheLookup]
        private IWebElement privacy;


        public PrivacyPage goToPrivacyPage()
        {
            privacy.Click();
            return new PrivacyPage(driver);
        }
        public OpenSourcePage goToOpenSourcePage()
        {
            openSource.Click();
            return new OpenSourcePage(driver);
        }
        public TelescopePage goToTelescopePage()
        {
            telescope.Click();
            return new TelescopePage(driver);
        }

        public InvestorPage goToInvestorsPage()
        {
            investors.Click();
            return new InvestorPage(driver);
        }

        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        public SearchPage goToCzech()
        {
            languagesIcon.Click();
            czechLang.Click();
            return new SearchPage(driver);
        }

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }
        public SearchPage test_search(string input_search)
        {
            searchIcon.Click();
            searchPanel.Click();
            searchPanel.SendKeys(input_search);
            searchPanel.Submit();
            return new SearchPage(driver);
        }

        // Returns the search string

        public OurWorkPage go_to_workPage()
        {
            learnMore.Click();
            return new OurWorkPage(driver);
        }


    }
}