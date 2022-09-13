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
            //List<Neighborhoods> neighborhoods = new List<Neighborhoods>();
            HttpClient client = apiService.Main();
            HttpResponseMessage res = await client.GetAsync("customers");
            //HttpResponseMessage resNghb = await client.GetAsync("neighborhoods");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customers>>(results);
            }

            //if (resNghb.IsSuccessStatusCode)
            //{
            //    var results = res.Content.ReadAsStringAsync().Result;
            //    neighborhoods = JsonConvert.DeserializeObject<List<Neighborhoods>>(results);
            //}
            //ViewBag.Neighborhoods = new SelectList(neighborhoods, "NghbID", "NghbName");
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
