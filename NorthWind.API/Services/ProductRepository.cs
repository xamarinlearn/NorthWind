using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.API.Interfaces;
using NorthWind.API.Models;

namespace NorthWind.API.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public IEnumerable<Product> All => _products;

        public ProductRepository()
        {
            InitializeData();
        }
        public void Delete(int id)
        {
            Product productToDelete = Find(id);
            _products.Remove(productToDelete);
        }
        public Product Find(int id)
        {
            return _products.FirstOrDefault(p => p.ID == id);
        }

        public bool DoesProductExist(int id)
        {
            return _products.Any(p => p.ID == id);
        }

        public void Insert(Product newProduct)
        {
            _products.Add(newProduct);
        }

        public void Update(Product productToUpdate)
        {
            Product oldProduct = Find(productToUpdate.ID);
            int index = _products.IndexOf(oldProduct);
            _products.RemoveAt(index);
            _products.Insert(index, productToUpdate);
        }

        private void InitializeData()
        {
            _products = new List<Product>();

            Product Leche = new Product
            {
                ID =1,
                Name ="Leche",
                UnitsInStock=40,
                Price =2,
                
            };
            Product Queso = new Product
            {
                ID = 2,
                Name = "Queso",
                UnitsInStock = 50,
                Price = 1,

            };
            Product Crema = new Product
            {
                ID = 3,
                Name = "Crema",
                UnitsInStock = 40,
                Price = 3,
            };
            _products.Add(Queso);
            _products.Add(Leche);
            _products.Add(Crema);
        }
    }
}
