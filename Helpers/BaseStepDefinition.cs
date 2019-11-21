using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace AudenTests.Helpers
{    
    using System.Text;
    using System.Threading;      
    using OpenQA.Selenium.Support.PageObjects;    
    using System.IO;
    using AudenTests.PageObjects;
    using System.Drawing.Imaging;
    using System.Configuration;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Support.UI;

    [Binding]
    public class BaseStepDefinitions
    {
        public static IWebDriver Driver;
        protected static ShortTermLoanPage STP;

        [BeforeFeature]
        public static string FeatureName()
        {
            Console.WriteLine("Auden Test Execution Start");
            return FeatureContext.Current.FeatureInfo.Title;
        }

        [AfterScenario]
        [AfterFeature]
        public static void EndExecution()
        {
            try
            {
                Console.WriteLine("Auden Test Execution Complete");
                CloseTheBrowser(Driver);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot close all the open drivers, getting exception: " + e);
            }
        }

        public static void CloseTheBrowser(IWebDriver driver)
        {
            var exception = ScenarioContext.Current.TestError;
            var currentScenario = ScenarioContext.Current.ScenarioInfo.Title;
            driver = Driver;
            // take screenshot on failure
            if (ScenarioContext.Current.TestError != null & driver != null)
            {
               
                TakeScreenshot(currentScenario);
            }
            // take screenshot on test pass
            if (ScenarioContext.Current.TestError == null & driver != null)
            {               
                TakeScreenshot(currentScenario);
            }
            if (exception is NoSuchElementException)
            {
                Console.WriteLine("Element not Found on Page, in" + currentScenario);
            }
            Console.WriteLine("**** Trying to close driver instance ****");
            try
            {
                if (driver != null)
                {
                    driver.Close();
                    driver.Dispose();
                    Console.WriteLine("**** Driver Instance Closed ****");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("**** Not able to close Browser Instance ****");
            }
        }

        public static void TakeScreenshot(string pSTestName)
        {
            string currentDate = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            string aSTestName = pSTestName.Replace(' ', '_');    
            StringBuilder filename = new StringBuilder(aSTestName);
            filename.Append("-");
            filename.Append(currentDate);
            if (ScenarioContext.Current.TestError == null)
            {
                filename.Append("_PASSED");
            }
            else
            {
                filename.Append("_FAILED");
            }
            filename.Append(".png");
            string filePath = Path.Combine("C:\\AudenTests\\AudenTests\\Screenshot", filename.ToString());
          ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);           
        }

        public static void OpenAudenShortTermLoanPage()
        {
            try
            {
                Console.WriteLine("***" + FeatureContext.Current.FeatureInfo.Title + "***");
                var browser = ConfigurationManager.AppSettings["Browser"];
                if (browser == "Firefox")
                {
                    Console.WriteLine("**** Trying to Launch Firefox ****");
                    Driver = new FirefoxDriver();
                }
                if (browser == "IE")
                {
                    Console.WriteLine("**** Launch Internet Explorer ****");
                    Driver = new InternetExplorerDriver();
                }
                if (browser == "Chrome")
                {
                    Console.WriteLine("**** Launch Chrome ****");
                    Driver = new ChromeDriver();
                }
                if (ConfigurationManager.AppSettings["Resolution"] == "Desktop")
                {
                    Driver.Manage().Window.Maximize();
                }
                Console.WriteLine("**** Launch Auden Short Term Loan Page on " + browser + "****");
                Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
                //add implicit wait for Driver object
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                // initialize page object
                STP = new ShortTermLoanPage(Driver);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + " Error in Launching Auden Loan Page");
            }
        }



        
		
	}

}

