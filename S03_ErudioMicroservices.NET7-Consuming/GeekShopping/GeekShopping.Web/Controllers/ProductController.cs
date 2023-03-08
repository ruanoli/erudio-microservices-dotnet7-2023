using GeekShopping.Web.Interfaces;
using GeekShopping.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if(ModelState.IsValid) 
            {
                var product = await _productService.CreateProduct(model);

                if(product != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int id)
        {
            var product = await _productService.GetProductById(id);

            if(product != null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateProduct(model);

                if (product != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product != null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var product = await _productService.DeleteProduct(model.Id);

            if (product) return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }
    }
}
