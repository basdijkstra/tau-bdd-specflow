using OpenQA.Selenium;

namespace SpecFlowOnlineBank.Specs.Pages
{
    public class RequestLoanPage : BasePage
    {
        private readonly By textfieldLoanAmount = By.Id("amount");
        private readonly By textfieldDownPayment = By.Id("downPayment");
        private readonly By dropdownFromAccountId = By.Id("fromAccountId");
        private readonly By buttonDoSubmit = By.XPath("//input[@value='Apply Now']");
        private readonly By textlabelLoanApplicationResult = By.Id("loanStatus");

        public RequestLoanPage(WebDriver driver) : base(driver) { }

        public void SubmitLoanRequest(int amount, int downPayment, int fromAccountId)
        {
            SendKeys(this.textfieldLoanAmount, amount.ToString());
            SendKeys(this.textfieldDownPayment, downPayment.ToString());
            Select(this.dropdownFromAccountId, fromAccountId.ToString());
            Click(this.buttonDoSubmit);
        }

        public string GetLoanApplicationResult()
        {
            return GetElementText(this.textlabelLoanApplicationResult).ToLower();
        }
    }
}
