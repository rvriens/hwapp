using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/

        public IActionResult Index()
        {
            return View();
            //return "This is my default action...";
        }

        // 
        // GET: /Home/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}