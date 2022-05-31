// See https://aka.ms/new-console-template for more information

using Fincons.Academy.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

HttpClient productServiceClient=new HttpClient();
productServiceClient.BaseAddress = new Uri("https://localhost:7079/");

List<Product> prodottiDaCreare = new List<Product>();

for (int i=0; i < 10; i++){
    prodottiDaCreare.Add(new Product
    {
        Name = $"Product {i}",
        Price = 9.99m,
        Description = "Product from Web API Client"
    }
    );
}

foreach(var product in prodottiDaCreare){
    var response = await productServiceClient.PostAsJsonAsync("api/Products", product);
}

var getResponse = await productServiceClient.GetAsync("api/products");
var productList = await getResponse.Content.ReadFromJsonAsync<Product[]>();

for (int i = 0; i < productList!.Length; i++)
{
    Console.WriteLine($"ID:{productList[i].Id} - Name:{productList[i].Name} - Price:{productList[i].Price}");
}

Console.WriteLine("Operazione Terminata");
Console.ReadKey();



