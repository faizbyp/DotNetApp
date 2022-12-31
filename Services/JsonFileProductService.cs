using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DotNetApp.Models;
using Microsoft.AspNetCore.Hosting;

namespace DotNetApp.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName // Membuat path untuk db file.json agar selalu sesuai dengan lingkungannya (env)
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product>? GetProducts() // Meng-GET JsonFileName menjadi list, mengubahnya dari string -> objek
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}