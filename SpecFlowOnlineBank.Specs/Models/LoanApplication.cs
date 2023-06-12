namespace SpecFlowOnlineBank.Specs.Models
{
    public class LoanApplication
    {
        public string Applicant { get; set; } = string.Empty;
        public int Amount { get; set; } = 0;
        public string Status { get; set; } = "New";
    }
}
