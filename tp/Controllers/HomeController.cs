using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tp.Models;

namespace tp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Home/Person/all")]
        public IActionResult Person_()
        {
            Personal_info p = new Personal_info();
            List<Person> All_Person = p.GetAllPerson();
            ViewBag.Person_List = All_Person;
            return View();
        }
        [Route("Home/Person/{id}")]
        public IActionResult Person_id(int id)
        {
            Personal_info p = new Personal_info();
            Person person = p.GetPerson(id);
            ViewBag.person = person;
            return View();
        }
        [HttpGet]
        [Route("/Home/search")]
        public IActionResult PersonneSearch()
        {
            return View();
        }

        [HttpPost]
        [Route("/Home/SearchHandler")]
        public IActionResult SearchHandler(Form form)
        {
            string firstName = form.first_Name;
            string country = form.country;

            Personal_info request = new Personal_info();
            int id = request.GetPersonByNameCountry(firstName, country);
            return Redirect("Person/"+id);

        }
    }

}
