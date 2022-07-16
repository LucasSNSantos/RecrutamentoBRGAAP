using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("Customer/All")]
        public async Task<ActionResult> GetAllCustomers()
        {
            using (var httpClient = new HttpClient())
            {
                var req = "https://jsonplaceholder.typicode.com/todos";
                using (var res = await httpClient.GetAsync(req))
                {
                    string apiResponse = await res.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    return new JsonResult(list);
                }
            }
        }
        [HttpGet]
        [Route("Customer/Title")]
        public async Task<ActionResult> GetCustomersByTitle(string title)
        {
            using (var httpClient = new HttpClient())
            {
                var req = "https://jsonplaceholder.typicode.com/todos";
                using (var res = await httpClient.GetAsync(req))
                {
                    string apiResponse = await res.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    var query = (from item in list
                                 where item.title.Contains(title)
                                 select item).ToList();

                    return new JsonResult(query);
                }
            }
        }
        [HttpGet]
        [Route("Customer/Search")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var req = "https://jsonplaceholder.typicode.com/todos";
                using (var res = await httpClient.GetAsync(req))
                {
                    string apiResponse = await res.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    var query = (from item in list
                                 where item.ID == id
                                 select item).FirstOrDefault();

                    return new JsonResult(query);
                }
            }
        }
    }
}
