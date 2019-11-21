using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AudenTests.Helpers
{
    public class CustomVerification
    {

        public static StringBuilder VerificationErrors = new StringBuilder();

        
        public static void VerifyEquals(string expected, string actual, String msg)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertionException e)
            {
                VerificationErrors.Append(e);
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
                Console.WriteLine(msg + " Verification Failed in " + ", Expected : " + expected + "," + "Actual : " + actual);
            }
        }

        /// <summary>
        ///     Method to verify if a particular element is displayed on page        ///     
        /// </summary>

        public static void VerifyElementDisplayed(IWebElement expectedElement)
        {
            var exception = ScenarioContext.Current.TestError;
            string currentScenario = ScenarioContext.Current.ScenarioInfo.Title;
            var currentTestStep = ScenarioContext.Current.StepContext;
            try
            {
                Assert.IsTrue(expectedElement.Displayed);
                Console.WriteLine(" Verification Successful in " + currentScenario + ", Element " + expectedElement + " found on Page");
            }
            catch (Exception e)
            {                
                Console.WriteLine(e.StackTrace + " Verification Failed in " + currentScenario + ", Element " + expectedElement + " not found on Page");
                Assert.Fail();
                throw e;
            }
        }

    }
}
