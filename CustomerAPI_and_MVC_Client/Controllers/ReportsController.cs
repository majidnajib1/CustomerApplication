using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CustomerAPI_and_MVC_Client.Models;
using System.Net;

namespace CustomerAPI_and_MVC_Client.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return PartialView("NotFound");
            }

            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers/" + id.ToString());
            Customer customer = await response.Content.ReadAsAsync<Customer>();

            if (customer == null)
            {
                return PartialView("NotFound");
            }
            return PartialView(customer);
        }

        [HttpPost]
        public async Task<ActionResult> GetByCity(string city)
        {
            if (city == null)
            {
                return PartialView("NotFound");
            }

            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers?city=" + city);
            var results = await response.Content.ReadAsAsync<IEnumerable<Customer>>();

            if (results == null)
            {
                return PartialView("NotFound");
            }
            return PartialView(results);
        }

        [HttpPost]
        public async Task<ActionResult> GetByCounty(string county)
        {
            
            if (county == null)
            {
                return PartialView("NotFound");
            }

            
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers?county="+ county);
            var results = await response.Content.ReadAsAsync<IEnumerable<Customer>>();

            if (results == null)
            {
                return PartialView("NotFound");
            }
            return PartialView(results);
        }


    }
}