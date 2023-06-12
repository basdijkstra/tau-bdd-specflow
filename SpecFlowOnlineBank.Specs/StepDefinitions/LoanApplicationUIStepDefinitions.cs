using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SpecFlowOnlineBank.Specs.Pages;

namespace SpecFlowOnlineBank.Specs.StepDefinitions
{
    [Binding]
    [Scope(Tag = "userinterface")]
    public class LoanApplicationUIStepDefinitions
    {
        private WebDriver driver;

        [BeforeScenario]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");

            this.driver = new ChromeDriver(options);
            this.driver.Manage().Window.Maximize();
        }

        [Given(@"John is an active ParaBank customer")]
        public void GivenJohnIsAnActiveParaBankCustomer()
        {
            new LoginPage(this.driver)
                .LoginAs("john", "demo");
        }

        [When(@"they apply for a (\d+) dollar loan")]
        public void WhenTheyApplyForADollarLoan(int loanAmount)
        {
            new AccountOverviewPage(this.driver)
                .SelectMenuItem("Request Loan");

            new RequestLoanPage(this.driver)
                .SubmitLoanRequest(loanAmount, 1000, 12345);
        }

        [Then(@"the loan application is (approved|denied)")]
        public void ThenTheLoanApplicationIsApproved(string expectedResult)
        {
            Assert.That(
                new RequestLoanPage(this.driver).GetLoanApplicationResult(),
                Is.EqualTo(expectedResult)
                );
        }

        [When(@"their monthly income is (\d+)")]
        public void WhenTheirMonthlyIncomeIs(int monthlyIncome)
        {
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}
