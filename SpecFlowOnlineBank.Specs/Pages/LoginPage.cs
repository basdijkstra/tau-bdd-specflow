using OpenQA.Selenium;

namespace SpecFlowOnlineBank.Specs.Pages
{
    public class LoginPage : BasePage
    {
        // private readonly string pageUrl = "https://parabank.parasoft.com";
        private readonly string pageUrl = "http://localhost:8080/parabank";

        private readonly By textfieldUsername = By.Name("username");
        private readonly By textfieldPassword = By.Name("password");
        private readonly By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(WebDriver driver) : base(driver)
        {
            Open(pageUrl);
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(this.textfieldUsername, username);
            SendKeys(this.textfieldPassword, password);
            Click(this.buttonDoLogin);
        }
    }
}
