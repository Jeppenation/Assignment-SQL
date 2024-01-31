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

            try
            {
                var address = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
                address ??= _addressRepository.Create(new AddressesEntity { StreetName = streetName, PostalCode = postalCode, City = city });

                return address;
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Read per streetname
        public AddressesEntity GetAdressByStreetName (string streetName)
        {
            try 
            {
                var address = _addressRepository.Get(x => x.StreetName == streetName);
                return address;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }

            
        }

        //read per postalcode
        public AddressesEntity GetAdressByPostalCode(string postalCode)
        {
            try
            {
                var address = _addressRepository.Get(x => x.PostalCode == postalCode);
                return address;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }

        }

        //read per city
        public AddressesEntity GetAdressByCity(string city)
        {
            try
            {
                var address = _addressRepository.Get(x => x.City == city);
                return address;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Read All
        public IEnumerable<AddressesEntity> GetAllAddresses()
        {
            try
            {
                var address = _addressRepository.GetAll();
                return address;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Update
        public AddressesEntity updateaddress(AddressesEntity addressesEntity)
        {
            try
            {
                var address = _addressRepository.Update(x => x.Id == addressesEntity.Id, addressesEntity);
                return address;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Delete
        public void DeleteAddress(int id)
        {
            try
            {
                _addressRepository.Delete(x => x.Id == id);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
