using ConsoleApp.Entities;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services;

internal class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressService _addressService;
    private readonly RoleService _roleService;

    public CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService)
    {
        _customerRepository = customerRepository;
        _addressService = addressService;
        _roleService = roleService;
    }

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        var roleEntity = _roleService.CreateRole(roleName);
        var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);
        var customerEntity = _customerRepository.Get(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email);

        if (customerEntity == null)
        {
            customerEntity ??= _customerRepository.Create(new CustomerEntity { FirstName = firstName, LastName = lastName, Email = email });
        }

        return customerEntity;
    }
    
    public CustomerEntity GetCustomer(string firstName, string lastName, string email)
    {
        var customerEntity = _customerRepository.Get(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email);
        return customerEntity;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetAll()
    {
        var roles = _customerRepository.GetAll();
        return roles;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updatedCustomerEntity;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }
}