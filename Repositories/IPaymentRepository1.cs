using KolokwiumCF.Models;

namespace KolokwiumCF.Repositories
{
    public interface IPaymentRepository1
    {
        Task<int> AddPaymentAsync(Payment payment);
    }
}