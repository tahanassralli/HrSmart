using Hrsmart.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace HrSmart.web.Controllers
{
    public class mvctestController : Controller
    {
        // GET: mvctest
        public ActionResult Index()
        {
            List<Recruter> lst = new List<Recruter>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = client.GetAsync("Api/Recruter").Result;
            if (Response.IsSuccessStatusCode)
            {
                lst = Response.Content.ReadAsAsync<List<Recruter>>().Result;
            }


            return View(lst);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recruter re)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:22905/");
            client.PostAsJsonAsync<Recruter>("Api/Recruter", re);
            return View(re);
        }


    }
}