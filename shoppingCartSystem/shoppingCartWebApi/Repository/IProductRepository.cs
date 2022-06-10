using shoppingCartWebApi.Models;
using System.Collections.Generic;

namespace shoppingCartWebApi.Repository
{
    public interface IProductRepository
    {       
        Product Create(Product product);
        IEnumerable<Product> GetAll();
        Product GetProduct(int id);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        
    }
}
