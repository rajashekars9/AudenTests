using AudenTests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudenTests.PageObjects
{
    public class ShortTermLoanPage
    {
        public IWebDriver driver;
        public ShortTermLoanPage(IWebDriver driver)
        {            
            this.driver = driver;            
        }
               

        #region Methods
              
        public IWebElement getLoanAmtsection
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("section[class='loan-amount']"));
            }
        }

        public IWebElement getLoanAmtsectionDfltValueDiv
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("div[class='loan-amount__header__amount']"));
            }
        }

        public IWebElement getLoanAmtSlider
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("input[name='amount']"));
            }
        }

        public IWebElement getLoanMinMaxAmtRangeDIV
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("div[class='loan-amount__header__range']>span"));
            }
        }

        public IWebElement getRepaymentSecExpDIV
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("span[class='loan-schedule__tab__panel__header__button__icon"));
            }
        }

        public IWebElement selectRepaymentDateSection(int date)
        {
          return this.driver.FindElement(By.CssSelector("button[id='monthly'][value='"+date+"']"));            
        }

        public IWebElement firstRepaymentScheduleDate()
        {
            return this.driver.FindElement(By.CssSelector("span[class='loan-schedule__tab__panel__detail__tag']"));
        }


        #endregion
    }
}
