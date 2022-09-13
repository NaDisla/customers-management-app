using customers_management_app.MainService;
using customers_management_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace customers_management_app.Controllers
{
    public class AddressesController : Controller
    {
        ApiService apiService = new ApiService();
        static int customerId = 0;
        public ActionResult Index()
        {
            return RedirectToAction("AllCustomers", "Customers");
        }

        public async Task<ActionResult> CreateAddress(int cust)
        {
            customerId = cust;
            List<Neighborhoods> neighborhoods = new List<Neighborhoods>();
            HttpClient client = new HttpClient();
            var stringNeighborhoods = await client.GetStringAsync($"{ApiService.baseUrl}neighborhoods");

            List<SelectListItem> countries = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "United States",
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "Dominican Republic",
                },
                new SelectListItem
                {
                    Value = "3",
                    Text = "Colombia",
                },
                new SelectListItem
                {
                    Value = "4",
                    Text = "Venezuela",
                },
                new SelectListItem
                {
                    Value = "5",
                    Text = "Brazil",
                },
                new SelectListItem
                {
                    Value = "6",
                    Text = "Mexico",
                },
            };
            if (stringNeighborhoods != null)
            {
                neighborhoods = JsonConvert.DeserializeObject<List<Neighborhoods>>(stringNeighborhoods);
            }
            ViewBag.Neighborhoods = new SelectList(neighborhoods, "NghbID", "NghbName");
            ViewBag.Countries = new SelectList(countries, "Text", "Text");
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Addresses newAddress, IFormCollection newAddressFormValues)
        {
            HttpClient client = new HttpClient();
            try
            {
                newAddress.CustID = customerId;
                newAddress.NghbID = int.Parse(newAddressFormValues["Neighborhoods"]);
                newAddress.AddrsCountry = newAddressFormValues["Countries"];

                string json = JsonConvert.SerializeObject(newAddress);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var post = await client.PostAsync($"{ApiService.baseUrl}addresses", content);

                if (post.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCustomers", "Customers");
                }

                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
