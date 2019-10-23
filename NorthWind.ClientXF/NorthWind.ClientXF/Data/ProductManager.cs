using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ClientXF.Data
{
   public class ProductManager
    {
        const string Url = "{servidor}/api/products/";

        private  HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
                (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            HttpClient client = GetClient();

            string result = await client.GetStringAsync(Url);

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            return products;
        }

        public async Task<Product> Add(Product newProduct)
        {
            HttpClient client = GetClient();
            String json = JsonConvert.SerializeObject(newProduct);
            StringContent content = new StringContent
                (json,Encoding.UTF8,"application/json");

            var response = await client.PostAsync(Url, content);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Product product = JsonConvert.DeserializeObject<Product>(jsonResponse);
            return product;
        }

        public async Task Update(Product productToUpdate)
        {
            HttpClient client = GetClient();

            String json = JsonConvert.SerializeObject(productToUpdate);
            StringContent content = new StringContent
                (json, Encoding.UTF8, "application/json");

            await client.PutAsync($"{Url}/{productToUpdate.ID}", content);

        }
        public async Task Delete(int id)
        {
            HttpClient client = GetClient();
            await client.DeleteAsync($"{Url}{id}");
        }
    }
}
