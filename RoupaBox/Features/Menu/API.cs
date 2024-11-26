using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.Features.Menu
{
    internal class API
    {
        public async Task main() { 
            HttpClient client = new HttpClient();

            string apiUrl = "https://fakestoreapi.com/products";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jsonResult = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    foreach (var item in jsonResult)
                    {
                        Console.WriteLine($"ID: {item.id}\n" +
                            $"Nome: {item.title}\n" +
                            $"Preço: {item.price}\n" +
                            $"Descrição: {item.description}\n" +
                            $"Categoria: {item.category}\n" +
                            $"Imagem: {item.image}\n" +
                            $"Avaliação: {item.rating.rate}\n" +
                            $"Qtd Avaliação: {item.rating.count}\n");
                    }

                } else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                }
            } catch (Exception ex)
            {
                Console.Write($"Erro: {ex.Message}");
            }
        }
    }
}
