using Demo.DataAccess.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:44390/api");

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        //private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            //_client = new HttpClient(); 
            //_client.BaseAddress = baseAddress;
        }
        
        public IActionResult Index()
        {
            //HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/Get");
            //if(response.IsSuccessStatusCode) {
            //    string data = response.Content.ReadAsStringAsync().Result;
            //}
            IList<Category> listofCategory=_db.Categories.ToList();

            return View(listofCategory);
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

        public IActionResult Details(int id)
        { 



            var  objCategory=_db.Categories.FirstOrDefault(h=>h.ID==id);
            return View(objCategory ); 
        }

    }
}