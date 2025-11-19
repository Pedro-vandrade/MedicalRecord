using Microsoft.AspNetCore.Mvc;

namespace MedicalRecord.Controllers
{
    public class NursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
