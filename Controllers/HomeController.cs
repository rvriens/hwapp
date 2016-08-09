using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Interfaces;
using System.Linq;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {

        private IPersonRepository _personRepository;

        public HomeController(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

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

        public string PersonList()
        {
            return string.Format("Persons {0}", this._personRepository.ListAll().Count());
        }

        public string PersonAdd(string name)
        {
            this._personRepository.Add(new Models.Person() {Name=name});
            return "added";
        }
    }
}