using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.API.Models;

namespace NorthWind.API.Interfaces
{
   public interface IProductRepository
    {
        void Insert(Product newProduct);
        void Update(Product productToUpdate);
        void Delete(int id);
        IEnumerable<Product> All { get; }
        Product Find(int id);
        bool DoesProductExist(int id);
    }
}
