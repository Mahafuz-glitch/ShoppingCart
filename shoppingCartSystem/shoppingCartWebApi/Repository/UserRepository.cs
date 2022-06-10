using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// The implimentation of the IUser interface with all the methods
/// </summary>
namespace shoppingCartWebApi.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ShoppingCartContext _context;
        public UserRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        #region CreateUser
        public User Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }
        #endregion

        #region GetAllUser
        public IEnumerable<User> GetAll()
        {
            //return _context.Users;
            return _context.User.Include(address => address.AddressTable).ToList();
        }
        #endregion


        #region GetByEmail
        public User GetByEmail(string email)
        {
            return _context.User.FirstOrDefault(x => x.EmailId == email);
        }
        #endregion
        #region GetById
        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(u => u.ProfileId == id);
        }
        #endregion

    }
}
