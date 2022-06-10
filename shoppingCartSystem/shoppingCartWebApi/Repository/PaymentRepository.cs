using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCartWebApi.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly ShoppingCartContext _context;
        public PaymentRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        public Payment Create(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment;
        }
        public void DeletePayment(int id)
        {
            Payment pay = GetPayment(id);
            _context.Remove(pay);
            _context.SaveChanges();
        }
        public IEnumerable<Payment> GetAll()
        {
            return _context.Payment;
        }
        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public Payment GetPayment(int id)
        {
            return _context.Payment.FirstOrDefault(u => u.PaymentId == id);
        }
        
    }
}
