using shoppingCartWebApi.Models;
using System.Collections.Generic;

namespace shoppingCartWebApi.Repository
{
    public interface IPaymentRepository
    {
        Payment Create(Payment payment);
        IEnumerable<Payment> GetAll();
        Payment GetPayment(int id);
        void DeletePayment(int id);
        void UpdatePayment(Payment payment);
    }
}
