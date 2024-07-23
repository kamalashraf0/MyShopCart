using Microsoft.AspNetCore.Mvc;
using myShop.DataAccess.Data;
using myShop.Entities.Models;


namespace myShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["Create"] = "Data has Added";
                return RedirectToAction("Index");
            }

            return View(category);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                NotFound();
            }

            var categoryInDb = _context.Categories.Find(id);

            return View(categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["Update"] = "Data has Updated";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                NotFound();
            }

            var categoryInDb = _context.Categories.Find(id);

            return View(categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var categoryInDb = _context.Categories.Find(id);
            if (categoryInDb == null)
            {
                NotFound("Index");
            }
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
