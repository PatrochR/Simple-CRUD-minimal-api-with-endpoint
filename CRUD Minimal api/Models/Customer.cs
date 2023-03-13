namespace CRUD_Minimal_api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class CustomerDto 
    {
        public required string Name { get; set; } 
        public required string Address { get; set; } 
        public int Age { get; set; }
    }

    public static class CustomerExtension 
    {
        public static Customer DtoToCustomer (this CustomerDto customer)
        {
            return new Customer { Address = customer.Address, Age = customer.Age, Name = customer.Name };
        }
    }
}
