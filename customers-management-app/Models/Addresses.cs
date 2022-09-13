namespace customers_management_app.Models
{
    public class Addresses
    {
        public int AddrsID { get; set; }
        public Neighborhoods NgbhID { get; set; }
        public string AddrsStreet1 { get; set; }
        public string AddrsStreet2 { get; set; }
        public string AddrsCountry { get; set; }

    }
}
