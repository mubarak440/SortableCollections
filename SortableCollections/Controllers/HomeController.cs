using Microsoft.AspNetCore.Mvc;
using SortableCollections.Models;
using System.Diagnostics;

namespace SortableCollections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index(string sortOrder)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "city" : "";
            ViewData["StateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "state" : "";
            ViewData["PhoneSortParm"] = String.IsNullOrEmpty(sortOrder) ? "phone" : "";

            

            var contacts = new[]
            {
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 3, Name="lisa", City="San Jose",State="CA",Phone="345"},
        
    };



           List<Contact> objList = new List<Contact>();
            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id":
                        {
                            // modify contacts to be ordered by Id

                            var orderedItems = contacts.OrderBy(s => s.Id);
                            objList.AddRange(orderedItems);
                            contacts = objList.ToArray();
                            break;
                        }
                    case "name":
                        {
                            var orderedItems = contacts.OrderBy(s => s.Name);
                            objList.AddRange(orderedItems);
                            contacts = objList.ToArray();
                            break;
                        }
                    case "city":
                        {
                            var orderedItems = contacts.OrderBy(s => s.City);
                            objList.AddRange(orderedItems);
                            contacts = objList.ToArray();
                            break;
                        }
                    case "state":
                        {
                            var orderedItems = contacts.OrderBy(s => s.State);
                            objList.AddRange(orderedItems);
                            contacts = objList.ToArray();
                            break;
                        }
                    default:
                        {
                            var orderedItems = contacts.OrderBy(s => s.Phone);
                            objList.AddRange(orderedItems);
                            contacts = objList.ToArray();
                            break;
                        }
                }
            }

            return View(contacts);
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
    }
}