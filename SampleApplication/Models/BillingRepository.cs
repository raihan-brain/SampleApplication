using Microsoft.EntityFrameworkCore;

namespace SampleApplication.Models
{
    public class BillingRepository : IBillingRepository
    {
        private readonly BillingContext _context;
        private readonly ILogger<BillingRepository> _logger;

        public BillingRepository(BillingContext context, ILogger<BillingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees
                       .OrderBy(e => e.Name)
                       .ToListAsync();
                return employees;
            }
            catch (Exception ex)
            {

                _logger.LogError($"could not get empolyees: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                var customers = await _context.Customers
                       .OrderBy(c => c.CompanyName)
                       .ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError($"could not get customers: {ex.Message}");

                throw;
            }
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"could not get saved: {ex.Message}");
                throw;
            }
        }

        public async Task<TimeBill?> GetTimeBill(int id)
        {
            var bill = await _context.TimeBills.FindAsync(id);
            return bill;
        }

        public void AddEntity<T>(T model) where T : notnull
        {
            _context.Add(model);
        }
    }
}
