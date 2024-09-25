
namespace SampleApplication.Models
{
    public interface IBillingRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<bool> SaveChanges();
        void AddEntity<T> (T model) where T : notnull;
        Task <TimeBill?> GetTimeBill(int id);
       
    }
}