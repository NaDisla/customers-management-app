namespace customers_management_app.Models.ViewModels
{
    public class CustomersViewModelDetail
    {
        public int CustID { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string CustPhone { get; set; }
        public List<Addresses> Addresses { get; set; }
    }
}
