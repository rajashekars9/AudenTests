using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AudenTests.Helpers
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;            
        }

    }
}
