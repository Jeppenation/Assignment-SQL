using Infrastructure.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Xml.Serialization;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class AddressServices
    {
        private readonly AddressRepository _addressRepository;

        public AddressServices(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        //Create
        public  AddressesEntity CreateAddress (string streetName, string postalCode, string city)
        {
            var address = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            address ??= _addressRepository.Create(new AddressesEntity {StreetName = streetName, PostalCode = postalCode, City = city });

            return address;
        }

        //Read per streetname
        public AddressesEntity GetAdressByStreetName (string streetName)
        {
            var address = _addressRepository.Get(x => x.StreetName == streetName);
            return address;
        }

        //read per postalcode
        public AddressesEntity GetAdressByPostalCode(string postalCode)
        {
            var address = _addressRepository.Get(x => x.PostalCode == postalCode);
            return address;
        }

        //read per city
        public AddressesEntity GetAdressByCity(string city)
        {
            var address = _addressRepository.Get(x => x.City == city);
            return address;
        }

        //Read All
        public IEnumerable<AddressesEntity> GetAllAddresses()
        {
            var address = _addressRepository.GetAll();
            return address;
        }

        //Update
        public AddressesEntity updateaddress(AddressesEntity addressesEntity)
        {
            var addresstoupdate = _addressRepository.Update(x => x.Id == addressesEntity.Id, addressesEntity);
            return addresstoupdate;
        }

        //Delete
        public void DeleteAddress(int id)
        {
             _addressRepository.Delete(x => x.Id == id);
           
        }

    }
}
