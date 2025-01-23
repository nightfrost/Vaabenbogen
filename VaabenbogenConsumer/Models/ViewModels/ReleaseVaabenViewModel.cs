namespace VaabenbogenConsumer.Models.ViewModels
{
    public class ReleaseVaabenViewModel
    {
        public string? newCvr {  get; set; }
        public string? newCompanyName { get; set; }
        public string? newCompanyPhone { get; set; }
        public string? newCompanyEmail { get; set; }
        public string? newCompanyJaegerId { get; set; }
        public string? newCpr { get; set; }
        public string? newFirstName { get; set; }
        public string? newLastName { get; set; }
        public string? newPhone { get; set; }
        public string? newEmail { get; set; }
        public string? newJaegerId { get; set; }
        public Vaaben? weaponToRelease { get; set; }
        public bool? isCompany { get; set; }

        public ReleaseVaabenViewModel(string? newCvr, string? newCompanyName, string? newCompanyPhone, string? newCompanyEmail, string? newCompanyJaegerId, string? newCpr, string? newFirstName, string? newLastName, string? newPhone, string? newEmail, string? newJaegerId, Vaaben? weaponToRelease, bool? isCompany)
        {
            this.newCvr = newCvr;
            this.newCompanyName = newCompanyName;
            this.newCompanyPhone = newCompanyPhone;
            this.newCompanyEmail = newCompanyEmail;
            this.newCompanyJaegerId = newCompanyJaegerId;
            this.newCpr = newCpr;
            this.newFirstName = newFirstName;
            this.newLastName = newLastName;
            this.newPhone = newPhone;
            this.newEmail = newEmail;
            this.newJaegerId = newJaegerId;
            this.weaponToRelease = weaponToRelease;
            this.isCompany = isCompany;
        }
        public ReleaseVaabenViewModel() { }
    }
}
