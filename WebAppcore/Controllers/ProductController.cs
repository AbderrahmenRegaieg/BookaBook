using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppcore.Data;
using WebAppcore.Models;

namespace WebAppcore.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Product> products = _db.Produits.Include(p => p.Category).ToList();
			return View(products);
		}
		public IActionResult Create()
		{
			ViewBag.list = _db.Categories.ToList();

			return View();
		}

		[HttpPost]


		public IActionResult Create(Product pro)
		{
			var p = _db.Produits.Find(pro.Reference);
			if (p == null)
			{
				_db.Produits.Add(pro);
				_db.SaveChanges();
				TempData["Success"] = "Product Created Successfully";
			}


			return RedirectToAction("Index", "Product");
		}
		[HttpGet]
		public ActionResult Delete(String? Ref)
		{
			if (Ref == null)
			{
				return NotFound();
			}
			var prod = _db.Produits.Find(Ref);
			if (prod == null)
			{
				return NotFound();
			}

			_db.Produits.Remove(prod);
			_db.SaveChanges();
			TempData["Success"] = "Product Deleted Successfully";
			return RedirectToAction("Index", "Product");

		
		}
		[HttpGet]
		public IActionResult Edit(String? id)
		{
			if (id == null )
			{
				 return NotFound();
			}
			var prod = _db.Produits.Find(id);
			if (prod == null)
			{
				return NotFound();
			}
			ViewBag.list = _db.Categories.ToList();
			return View(prod);

		}
		[HttpPost]
		public ActionResult Edit(Product product)
		{
			_db.Produits.Update(product);
			_db.SaveChanges();
			TempData["Success"] = "Product Updated Successfully";
			return RedirectToAction("Index", "Product");

		}

	} 

}
