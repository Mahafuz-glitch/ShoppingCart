using shoppingCartWebApi.Models;
using System.Collections.Generic;


namespace shoppingCartWebApi.Repository
{
    public interface IUserRepository
    { 
        User Create(User user); 
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
        User GetById(int id);
        
    }
}
