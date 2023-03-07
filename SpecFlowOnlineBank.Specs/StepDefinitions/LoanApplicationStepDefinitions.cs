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

        [When(@"they apply for a (.*) dollar loan")]
        public void WhenTheyApplyForADollarLoan(int p0)
        {
        }

        [Then(@"the loan application is approved")]
        public void ThenTheLoanApplicationIsApproved()
        {
        }

        [Then(@"the loan application is denied")]
        public void ThenTheLoanApplicationIsDenied()
        {
        }

        [When(@"their monthly income is (.*)")]
        public void WhenTheirMonthlyIncomeIs(int p0)
        {
        }
    }
}
