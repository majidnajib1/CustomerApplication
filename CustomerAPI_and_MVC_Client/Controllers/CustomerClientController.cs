using CustomerAPI_and_MVC_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomerAPI_and_MVC_Client.Controllers
{
    public class CustomerClientController : Controller
    {
        
        // GET: CustomerClient
        public async Task <ActionResult> Index()
        {
            
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers");
            var result = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
            return View(result);


        }




        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,LastName,Address_Line1,City,County,Post_Code,Telephone,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                await client.PostAsJsonAsync<Customer>("http://localhost:49401/api/customers", customer );
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers/" + id.ToString());
            Customer customer = await response.Content.ReadAsAsync<Customer>();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,Address_Line1,City,County,Post_Code,Telephone,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                await client.PutAsJsonAsync<Customer>("http://localhost:49401/api/customers/" + customer.ID.ToString(), customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }


         public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:49401/api/customers/" + id.ToString());
            Customer customer = await response.Content.ReadAsAsync<Customer>();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync("http://localhost:49401/api/customers/" + id.ToString());
            return RedirectToAction("Index");
          
        }
    }
}