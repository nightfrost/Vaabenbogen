namespace VaabenbogenConsumer.Models.ViewModels
{
    public class AddCustomerViewModel
    {
        public string? NewCvr { get; set; }
        public string? NewCompanyName { get; set; }
        public string? NewCompanyPhone { get; set; }
        public string? NewCompanyEmail { get; set; }
        public string? NewCompanyJaegerId { get; set; }
        public string? NewCpr { get; set; }
        public string? NewFirstName { get; set; }
        public string? NewLastName { get; set; }
        public string? NewPhone { get; set; }
        public string? NewEmail { get; set; }
        public string? NewJaegerId { get; set; }
        public bool? IsCompany { get; set; }

        public AddCustomerViewModel(string? newCvr, string? newCompanyName, string? newCompanyPhone, string? newCompanyEmail, string? newCompanyJaegerId, string? newCpr, string? newFirstName, string? newLastName, string? newPhone, string? newEmail, string? newJaegerId, bool? isCompany)
        {
            NewCvr = newCvr;
            NewCompanyName = newCompanyName;
            NewCompanyPhone = newCompanyPhone;
            NewCompanyEmail = newCompanyEmail;
            NewCompanyJaegerId = newCompanyJaegerId;
            NewCpr = newCpr;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
            NewPhone = newPhone;
            NewEmail = newEmail;
            NewJaegerId = newJaegerId;
            IsCompany = isCompany;
        }

        public AddCustomerViewModel()
        {
        }
    }
}
