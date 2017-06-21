using Hrsmart.Domain.Entites;
using HrSmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()

        { HrSmartContext db = new HrSmartContext();
            List<RefferingEmployee> lst = new List<RefferingEmployee>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("Api/RefferingEmployees").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<RefferingEmployee>>().Result;
            }


            return View(lst);
        }




        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RefferingEmployee re)
        {
            HrSmartContext db = new HrSmartContext();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<RefferingEmployee>("Api/RefferingEmployees", re);
            return RedirectToAction("Index");
        }

    }
}