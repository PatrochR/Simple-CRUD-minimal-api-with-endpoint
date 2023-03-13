namespace CRUD_Minimal_api.Repositories
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomerAsync();
        public Task<Customer?> GetCustomerByIdAsync(int id);
        public Task<bool> CreateCustomerAsync(Customer request);
        public Task<bool> UpdateCustomerAsync(Customer request , int id);
        public Task<bool> DeleteCustomerAsync(int id);
    }
}
