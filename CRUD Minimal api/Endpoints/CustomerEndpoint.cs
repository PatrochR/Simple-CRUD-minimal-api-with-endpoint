using CRUD_Minimal_api.Repositories;

namespace CRUD_Minimal_api.Endpoints
{
    public static class CustomerEndpoint
    {
        public static void MapCustomer(this WebApplication app) 
        {
            app.MapGet("/Customer", async (ICustomerRepository _customerRepository) => Results.Ok(await _customerRepository.GetAllCustomerAsync()));
            app.MapGet("/Customer/{id}", async(ICustomerRepository _customerRepository , int id) => 
            {
               return Results.Ok(await _customerRepository.GetCustomerByIdAsync(id));
            } );
            app.MapPost("/Customer", async (ICustomerRepository _customerRepository, CustomerDto request) => 
            {
                return Results.Ok(await _customerRepository.CreateCustomerAsync(request.DtoToCustomer()));
            });
            app.MapPut("/Customer/{id}", 
                async (ICustomerRepository _customerRepository , CustomerDto request, int id) => 
                {
                    return Results.Ok(await _customerRepository.UpdateCustomerAsync(request.DtoToCustomer() , id));
                });
            app.MapDelete("/Customer/{id}", async (ICustomerRepository _customerRepository, int id) =>
            {
                return Results.Ok(await _customerRepository.DeleteCustomerAsync(id));
            });
        }
    }
}
