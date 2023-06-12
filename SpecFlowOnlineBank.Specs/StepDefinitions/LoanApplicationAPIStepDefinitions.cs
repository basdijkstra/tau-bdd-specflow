using NUnit.Framework;
using RestAssured.Request.Builders;
using SpecFlowOnlineBank.Specs.Models;
using static RestAssured.Dsl;

namespace SpecFlowOnlineBank.Specs.StepDefinitions
{
    [Binding]
    [Scope(Tag = "api")]
    public class LoanApplicationAPIStepDefinitions
    {
        private RequestSpecification requestSpecification;

        private long customerId;

        private LoanApplicationResponse response;

        [BeforeScenario]
        public void CreateRequestSpecification()
        {
            this.requestSpecification = new RequestSpecBuilder()
                .WithHostName("localhost")
                .WithBasePath("/parabank/services/bank")
                .WithPort(8080)
                .WithHeader("Accept", "application/json")
                .Build();
        }

        [Given(@"John is an active ParaBank customer")]
        public void GivenJohnIsAnActiveParaBankCustomer()
        {
            this.customerId = (long)Given()
                .Spec(this.requestSpecification)
                .PathParam("username", "john")
                .PathParam("password", "demo")
                .When()
                .Get("/login/{{username}}/{{password}}")
                .Then()
                .StatusCode(200)
                .And()
                .Extract().Body("$.id");
        }

        [When(@"they apply for a (\d+) dollar loan")]
        public void WhenTheyApplyForADollarLoan(int loanAmount)
        {
            this.response = (LoanApplicationResponse)Given()
                .Spec(this.requestSpecification)
                .QueryParam("customerId", this.customerId)
                .QueryParam("amount", loanAmount)
                .QueryParam("downPayment", 1000)
                .QueryParam("fromAccountId", 12345)
                .When()
                .Post("/requestLoan")
                .Then()
                .StatusCode(200)
                .And()
                .DeserializeTo(typeof(LoanApplicationResponse));
        }

        [Then(@"the loan application is (approved|denied)")]
        public void ThenTheLoanApplicationIsApproved(string expectedResult)
        {
            bool expectedApproved = expectedResult.Equals("approved");

            Assert.That(this.response.approved, Is.EqualTo(expectedApproved));
        }

        [When(@"their monthly income is (\d+)")]
        public void WhenTheirMonthlyIncomeIs(int monthlyIncome)
        {
        }

        [AfterScenario]
        public void CloseBrowser()
        {
        }
    }
}
