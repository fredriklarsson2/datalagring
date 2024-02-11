using ConsoleApp.Entities;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services;

internal class AddressService
{
    private readonly AddressRepository _adressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _adressRepository = addressRepository;
    }

    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);

        if (addressEntity == null)
        {
            addressEntity ??= _adressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
        }
        return addressEntity;
    }

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddressEntity GetAddressById(int id)
    {
        var addressEntity = _adressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAddresses()
    {
        var addresses = _adressRepository.GetAll();
        return addresses;
    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updatedAddressEntity = _adressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }

    public void DeleteAddress(int id)
    {
        _adressRepository.Delete(x => x.Id == id);
    }
}
