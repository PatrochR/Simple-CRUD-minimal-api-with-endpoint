namespace CRUD_Minimal_api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateCustomerAsync(Customer request)
        {
            try
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await GetCustomerByIdAsync(id);
            if (customer == null) 
            {
                return false;
            }
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer request, int id)
        {
            var customer = await GetCustomerByIdAsync(id);

            if (customer is null)
            {
                return false;
            }

            customer.Name = request.Name;
            customer.Address = request.Address;
            customer.Age = request.Age;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
