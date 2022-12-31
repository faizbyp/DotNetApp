using System.Collections.Generic;
using DotNetApp.Models;
using DotNetApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DotNetApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService { get; }
        public IEnumerable<Product>? Products { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService; // Memanggil service yg diperlukan pada page
        }

        public void OnGet() => Products = ProductService.GetProducts();
    }
}
