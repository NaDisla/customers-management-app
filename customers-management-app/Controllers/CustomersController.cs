using customers_management_app.MainService;
using customers_management_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace customers_management_app.Controllers
{
    public class CustomersController : Controller
    {
        ApiService apiService = new ApiService();
        public async Task<ActionResult> AllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            HttpClient client = new HttpClient();
            string customersString = await client.GetStringAsync($"{ApiService.baseUrl}customers");

            if (customersString != null)
            {
                customers = JsonConvert.DeserializeObject<List<Customers>>(customersString);
            }

            return View(customers);
        }

        public async Task<ActionResult> CustomerDetails(int id)
        {
            Customers customer = new Customers();
            HttpClient client = new HttpClient();
            string customerString = await client.GetStringAsync($"{ApiService.baseUrl}customers/{id}");

            List<Addresses> addresses = new List<Addresses>();
            string addressString = await client.GetStringAsync($"{ApiService.baseUrl}addresses/addresses_by_customer/{id}");

            if (customerString != null)
            {
                customer = JsonConvert.DeserializeObject<Customers>(customerString);
            }

            if (addressString != null)
            {
                addresses = JsonConvert.DeserializeObject<List<Addresses>>(addressString);
            }

            if(customer != null && addresses != null)
            {
                customer.Addresses = addresses;
            }
            return View(customer);
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customers newCustomer)
        {
            HttpClient client = new HttpClient();
            try
            {
                string json = JsonConvert.SerializeObject(newCustomer);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var post = await client.PostAsync($"{ApiService.baseUrl}customers", content);

                if (post.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCustomers", "Customers");
                }

                return RedirectToAction("AllCustomers", "Customers");
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> EditCustomer(int id)
        {
            Customers customer = new Customers();
            HttpClient client = new HttpClient();
            string customerString = await client.GetStringAsync($"{ApiService.baseUrl}customers/{id}");

            if (customerString != null)
            {
                customer = JsonConvert.DeserializeObject<Customers>(customerString);
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Customers custEdited)
        {
            HttpClient client = new HttpClient();
            try
            {
                string json = JsonConvert.SerializeObject(custEdited);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var put = await client.PutAsync($"{ApiService.baseUrl}customers/{custEdited.CustID}", content);

                if (put.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCustomers", "Customers");
                }

                return RedirectToAction("AllCustomers", "Customers");
            }
            catch
            {
                return BadRequest();
            }
        }
        
        public ActionResult AddAddress(int cust)
        {
            return RedirectToAction("CreateAddress", "Addresses", new { cust = cust });
        }

        public async Task<ActionResult> DeleteCustomer(int id)
        {
            Customers customer = new Customers();
            HttpClient client = new HttpClient();
            string customerString = await client.GetStringAsync($"{ApiService.baseUrl}customers/{id}");

            if (customerString != null)
            {
                customer = JsonConvert.DeserializeObject<Customers>(customerString);
            }
            return View(customer);
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var delete = await client.DeleteAsync($"customers/{id}");

                if (delete.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCustomers", "Customers");
                }

                return RedirectToAction("AllCustomers", "Customers");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
