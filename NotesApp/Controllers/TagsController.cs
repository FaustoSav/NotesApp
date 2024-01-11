using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Controllers
{
    public class TagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
