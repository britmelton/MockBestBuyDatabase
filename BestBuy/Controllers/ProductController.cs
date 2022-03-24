using BbDatabase;
using Microsoft.AspNetCore.Mvc;

namespace BestBuy.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();

            return View(products);
        }

     
    }
}
