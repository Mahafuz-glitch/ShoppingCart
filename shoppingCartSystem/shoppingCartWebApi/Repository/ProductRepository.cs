using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Implementation of th IProduct Interface with all the methods
/// </summary>
namespace shoppingCartWebApi.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ShoppingCartContext _context;

        public ProductRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        #region Create
        public Product Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }
        #endregion
        #region DeleteProduct
        public void DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            _context.Remove(product);
            _context.SaveChanges();
        }
        #endregion
        #region GetAll
        public IEnumerable<Product> GetAll()
        {
            return _context.Product;
        }
        #endregion
        #region GetProduct
        public Product GetProduct(int id)
        {
            return _context.Product.FirstOrDefault(u => u.ProductId == id);
        }
        #endregion
        #region UpdateProduct
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
        #endregion

    }
}
