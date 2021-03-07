using HWMultipleRows.Data;
using HWMultipleRows.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HWMultipleRows.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
        @"Data Source=.\sqlexpress; Initial Catalog=People;Integrated Security=true;";
        public IActionResult Index()
        {
            PeopleDB db = new(_connectionString);
            PeopleViewModel vm = new()
            {
                People = db.GetPeople()
            };
            if(TempData["message"] != null)
            {
                vm.Alert = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult AddPeople()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            PeopleDB db = new(_connectionString);
            bool pplAdded = false;
            foreach(Person p in people)
            {
                if (!string.IsNullOrEmpty(p.FirstName))
                {
                    db.AddPeson(p);
                    pplAdded = true;
                } 
            }
            string message = pplAdded ? "People added successfully!" : "No people added";
            TempData["message"] =message;
            return Redirect("/Home/Index");
        }
    }
}
