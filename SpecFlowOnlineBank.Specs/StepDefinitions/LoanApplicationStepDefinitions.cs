using System;
using TechTalk.SpecFlow;

namespace SpecFlowOnlineBank.Specs.StepDefinitions
{
    [Binding]
    public class LoanApplicationStepDefinitions
    {
        [Given(@"John is an active ParaBank customer")]
        public void GivenJohnIsAnActiveParaBankCustomer()
        {
        }

        [When(@"they apply for a (\d+) dollar loan")]
        public void WhenTheyApplyForADollarLoan(int loanAmount)
        {
        }

        [Then(@"the loan application is (approved|denied)")]
        public void ThenTheLoanApplicationIsApprovedOrDenied(string expectedResult)
        {
        }

        [When(@"their monthly income is (\d+)")]
        public void WhenTheirMonthlyIncomeIs(int monthlyIncome)
        {
        }
    }
}
