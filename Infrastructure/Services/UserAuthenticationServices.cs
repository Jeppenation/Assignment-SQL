using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class UserAuthenticationServices
    {
        private readonly UserAuthenticationRepository _userAuthenticationRepository;

        public UserAuthenticationServices(UserAuthenticationRepository userAuthenticationRepository)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
        }

        //Create
        public UserAuthenticationsEntity CreateUserAuthentication(string email, string password)
        {
            try
            {
                var userAuthentication = _userAuthenticationRepository.Get(x => x.Email == email && x.Password == password);
                userAuthentication ??= _userAuthenticationRepository.Create(new UserAuthenticationsEntity { Email = email, Password = password });

                return userAuthentication;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }

        }
        //Read by email

        public UserAuthenticationsEntity GetUserAuthenticationByEmail(string email)
        {
            try
            {
                var userAuthentication = _userAuthenticationRepository.Get(x => x.Email == email);
                return userAuthentication;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Update Password
        public UserAuthenticationsEntity UpdateUserAuthenticationPassword(string email, string newPassword)
        {
            try
            {
                var userAuthentication = _userAuthenticationRepository.Get(x => x.Email == email);

                if (userAuthentication != null)
                {
                    // Update the password
                    userAuthentication.Password = newPassword;
                    _userAuthenticationRepository.UpdateOne(userAuthentication);
                    return userAuthentication;
                }
                else
                {
                    Debug.WriteLine($"No user found with email: {email}");
                    return null!;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null!;
            }
        }

        //Delete
        public bool DeleteUserAuthentication(string email)
        {
            try
            {
                var userAuthentication = _userAuthenticationRepository.Get(x => x.Email == email);
                if (userAuthentication != null)
                {
                    _userAuthenticationRepository.Delete(x => x.Email == email);
                    return true;
                }
                else
                {
                    Debug.WriteLine($"No user found with email: {email}");
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }



    }
}


