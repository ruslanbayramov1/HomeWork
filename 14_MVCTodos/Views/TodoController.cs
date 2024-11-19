using Microsoft.AspNetCore.Mvc;

namespace _14_MVCTodos.Views
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{ 
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
