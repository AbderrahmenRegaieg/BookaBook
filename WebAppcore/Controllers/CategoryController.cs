using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebAppcore.Data;
using WebAppcore.IRepositly;
using WebAppcore.Models;

namespace WebAppcore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository db) { 
            categoryRepository = db;
        }
        public IActionResult Index()
        {
            ViewBag.list = categoryRepository.GetAll().ToList();
			List<Category> categories = categoryRepository.GetAll().ToList();
			return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
		public IActionResult Edit()
		{
			return View();
		}



		[HttpPost]


		public IActionResult Create(Category category)
		{
            categoryRepository.Add(category);
            categoryRepository.Save();	
			TempData["Success"] = "category Created Successfully";

			return RedirectToAction("Index","Category");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if(id==null || id == 0){
				return View();
			}
			var categ = categoryRepository.Get(u=>u.Id==id);
			if (categ == null)
			{
				return NotFound();
			}
			return View(categ);
			
		}
		[HttpPost]


		public IActionResult Edit(Category category)
		{
			categoryRepository.Update(category);
			categoryRepository.Save();
			TempData["Success"] = "category Edited Successfully";

			return RedirectToAction("Index", "Category");
		}
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categ = categoryRepository.Get(u => u.Id == id);
			if (categ == null)
			{
				return NotFound();
			}
			categoryRepository.Delete(categ);
			categoryRepository.Save();
			TempData["Success"] = "category Deleted Successfully";
			return RedirectToAction("Index", "Category");
		}
	




	}
}
