namespace customers_management_app.Models
{
    public class CustomerAddresses
    {
        public int CustAddrsID { get; set; }
        public Customers CustID { get; set; }
        public Addresses AddrsID { get; set; }
    }
}
