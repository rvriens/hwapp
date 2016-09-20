using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Interfaces;
using System.Linq;

namespace aspnetcoreapp.Controllers
{
    public class CommentController : Controller
    {

        private ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
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

        [HttpGet]
        public JsonResult comments()
        {
            return Json(this._commentRepository.ListAll());
        }

        [HttpPost]
        public JsonResult comments(Models.Comment comment)
        {
            this._commentRepository.Add(comment);
            return comments();
        }
    }
}