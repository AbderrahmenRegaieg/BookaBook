using Microsoft.AspNetCore.Mvc;
using WebAppcore.Data;
using WebAppcore.Models;

namespace WebAppcore.Controllers
{
    public class BuyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BuyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> list = _db.Produits.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Command(string Ref, int Qte)
        {
            var prod = _db.Produits.Find(Ref);

            if (prod == null)
            {
                TempData["error"] = "Product not found.";
                return RedirectToAction("Index");
            }

            if (Qte <= 0 || Qte > prod.Qte)
            {
                TempData["error"] = $"Invalid quantity. Available stock for {prod.Reference}: {prod.Qte}.";
                return RedirectToAction("Index");
            }

            var viewModel = new CommandClient
            {
                Product = prod,
                OrderedQuantity = Qte,
                TotalPrice = Qte * prod.Prix
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ConfirmOrder(string Reference, int Qte)
        {
            var productToUpdate = _db.Produits.Find(Reference);
            if (productToUpdate == null)
            {
                TempData["error"] = "Product not found for order confirmation.";
                return RedirectToAction("Index");
            }

            if (productToUpdate.Qte < Qte)
            {
                TempData["error"] = "Not enough stock to confirm order.";
                return RedirectToAction("Index");
            }

            var commandClient = new CommandClient
            {
                ProductReference = Reference,
                OrderedQuantity = Qte,
                TotalPrice = Qte * productToUpdate.Prix,
                OrderDate = DateTime.Now
            };

            _db.Commands.Add(commandClient);
            productToUpdate.Qte -= Qte; // Decrement stock
            _db.SaveChanges();

            TempData["Success"] = $"Order for {Qte} units of {Reference} confirmed!";
            return RedirectToAction("Index");
        }
        

	}
}