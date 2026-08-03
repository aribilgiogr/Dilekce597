using Dilekce597.Models;
using Dilekce597.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dilekce597.Controllers
{
    public class HomeController(IFeedbackService service) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var list = await service.GetAsync();
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var detail = await service.GetAsync(id);
            if (detail == null) return NotFound();
            return View(detail);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedbackCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await service.CreateAsync(model))
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu!");
            }
            return View(model);
        }
    }
}
