﻿using BbDatabase;
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

        public IActionResult DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();

            return View(products);
        }

        public IActionResult InsertProduct()
        {
            var prod = _productRepository.AssignCategory();

            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _productRepository.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = _productRepository.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _productRepository.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }


        public IActionResult ViewProduct(int id)
        {
            var product = _productRepository.GetProduct(id);

            return View(product);
        }



    }
}
