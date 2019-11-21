using AudenTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AudenTests.Steps.ShortTermLoan
{
    [Binding]
    public class ShortTermLoanSteps : BaseStepDefinitions
    {
        string loanAmtB4click;
        string loanAmtAftrclick;

        [Given(@"I launch Auden Short term loan page")]
        public void GivenILaunchAudenShortTermLoanPage()
        {
            OpenAudenShortTermLoanPage();
        }

        [Then(@"Short term loan page should be displayed with Loan amount section")]
        public void ThenShortTermLoanPageShouldBeDisplayedWithLoanAmountSection()
        {            
            CustomVerification.VerifyElementDisplayed(STP.getLoanAmtsection);
        }

        [Then(@"default loan amount value should be set to '(.*)'")]
        public void ThenDefaultLoanAmountValueShouldBeSetTo(string _pdfltLnAmt)
        {
            CustomVerification.VerifyEquals(_pdfltLnAmt, STP.getLoanAmtsectionDfltValueDiv.Text, "Default Loan Amount Value");
        }

        [Given(@"I edit default loan amount by clicking on the slider")]
        public void GivenIEditDefaultLoanAmountByClickingOnTheSlider()
        {
            // get loan value before click
            loanAmtB4click = STP.getLoanAmtsectionDfltValueDiv.Text;
            System.Threading.Thread.Sleep(2000);
            STP.getLoanAmtSlider.Click();
            // get loan value after click
            loanAmtAftrclick = STP.getLoanAmtsectionDfltValueDiv.Text;            
        }

        [Then(@"loan amount on slider should be updated")]
        public void ThenLoanAmountOnSliderShouldBeUpdated()
        {
            Assert.AreNotEqual(loanAmtB4click, loanAmtAftrclick);
        }

        [Then(@"minimum and maximum loan amount range should be '(.*)'")]
        public void ThenMinimumAndMaximumLoanAmountRangeShouldBe(string expLoanMinMaxRange)
        {
            System.Threading.Thread.Sleep(2000);
            string loanRange = STP.getLoanMinMaxAmtRangeDIV.Text;
            Assert.AreEqual(expLoanMinMaxRange, loanRange);
        }

        [When(@"I expand repayment day and select repayment date as '(.*)'")]
        public void GivenIExpandRepaymentDayAndSelectRepaymentDateAs(int date)
        {
            System.Threading.Thread.Sleep(2000);
            STP.getRepaymentSecExpDIV.Click();
            STP.selectRepaymentDateSection(date).Click();
            System.Threading.Thread.Sleep(2000);
        }
               

        [Then(@"First repayment text should be set to ""(.*)""")]
        public void ThenFirstRepaymentTextShouldBeSetTo(string firstRepayment)
        {
            StringAssert.Contains(firstRepayment, STP.firstRepaymentScheduleDate().Text);
        }





    }
}
