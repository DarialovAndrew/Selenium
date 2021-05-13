using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using SeleniumTesting.Pages;

namespace Selenium
{

    class EpamTest
    {
        string url = "https://www.epam.com/";

        ChromeDriver chromeDriver;

        ChromeDriverService service;

        public EpamTest(){
            service = ChromeDriverService.CreateDefaultService();

            var options = new ChromeOptions();
            options.AddArgument("--window-position=1300,1300");
            chromeDriver = new ChromeDriver(service, options);
            chromeDriver.Navigate().GoToUrl(url);
            }
        // get expected page 
        [Test]
        public void task1()
        {
            MainPage main = new MainPage(chromeDriver);
            main.goToPage();
            OurWorkPage page = main.go_to_workPage();
            string title = page.getPageTitle();
            if (title.Contains("our-work") || chromeDriver.Url.ToLower().Contains("our-work"))
            {
                Console.WriteLine("Search Passed");
            }
            else
            {
                Console.WriteLine("Search Failed");
            }
        }
        // get expected phone and address 
        [Test]
        public void task2()
        {
            try
            {
                chromeDriver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/ul/li[1]/a")).Click();
                var telephone = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/div[1]/div[1]/section/div/div[3]/div/p[2]/span/span/b[1]/span/span/a")).GetAttribute("innerHTML");
                var address = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/div[1]/div[1]/section/div/div[3]/div/p[1]/b/span/span")).GetAttribute("innerHTML");
                Console.WriteLine(telephone + " " + address);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(false.ToString());
            }
        }
        // get expected search results 
        [Test]
        public void task3()
        {
           
                String expected_keyword = "Bitcoin";
                String result_PageTitle;
                String search_string = "Bitcoin";

                MainPage home_page = new MainPage(chromeDriver);
                home_page.goToPage();
                //home_page.test_search(search_string);

                // SearchPage search_page = new SearchPage(driver); ;
                SearchPage final_page = home_page.test_search(search_string);

                // Ensure that the page load is complete    
                final_page.load_complete();

                //As the web page is loaded, we just check if the page title matches or not.
                result_PageTitle = final_page.getPageTitle();

                if (result_PageTitle.Contains(expected_keyword) || chromeDriver.Url.ToLower().Contains(expected_keyword))
                {
                    Console.WriteLine("Search Passed");
                }
                else
                {
                    Console.WriteLine("Search Failed");
                }
        }

        // get expected language 
        [Test]
        public void task4()
        {
            String result_PageTitle;
            String expected_title = "cz";
            MainPage home_page = new MainPage(chromeDriver);
            home_page.goToPage();

            SearchPage final_page = home_page.goToCzech();

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            Console.WriteLine(result_PageTitle.ToLower());
            Console.WriteLine(chromeDriver.Url.ToLower());

            if (chromeDriver.Url.ToLower().Contains(expected_title))
            {
                Console.WriteLine("Translate Test Passed");
            }
            else
            {
                Console.WriteLine("Translate Test Failed");
            }
        }

        //get price info
        [Test]
        public void task5()
        {
            MainPage home_page = new MainPage(chromeDriver);
            home_page.goToPage();

            InvestorPage page = home_page.goToInvestorsPage();

            var price = double.Parse(page.price(), System.Globalization.CultureInfo.InvariantCulture);

            if(price > 440.0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }

        }

        // check title of the telescope page 
        [Test]
        public void task6()
        {
            MainPage main = new MainPage(chromeDriver);
            main.goToPage();
            TelescopePage page = main.goToTelescopePage();
            string title = page.getPageTitle();
            if (title.Contains("telescopeai") || chromeDriver.Url.ToLower().Contains("telescopeai"))
            {
                Console.WriteLine("Search Passed");
            }
            else
            {
                Console.WriteLine("Search Failed");
            }
        }

        // check title of the OpenSource page
        [Test]
        public void task7()
        {
            MainPage main = new MainPage(chromeDriver);
            main.goToPage();
            OpenSourcePage page = main.goToOpenSourcePage();
            string title = page.getPageTitle();
            if (title.Contains("open-source") || chromeDriver.Url.ToLower().Contains("open-source"))
            {
                Console.WriteLine("Search Passed");
            }
            else
            {
                Console.WriteLine("Search Failed");
            }
        }


        [Test]
        public void task8()
        {
            MainPage main = new MainPage(chromeDriver);
            main.goToPage();
            PrivacyPage page = main.goToPrivacyPage();
            string title = page.getPageTitle();
            if (title.Contains("privacy-policy") || chromeDriver.Url.ToLower().Contains("privacy-policy"))
            {
                Console.WriteLine("Search Passed");
            }
            else
            {
                Console.WriteLine("Search Failed");
            }   
        }
    }
}
