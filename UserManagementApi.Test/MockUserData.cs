using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApis.Models;
using UserManagementApis.Services;

namespace UserManagementApi.Test
{
    public class MockUserData
    {
        public static List<UserDetails> UserData()
        {
            return new List<UserDetails>{
             new UserDetails{
                 Id = 1,
                 UserName = "Akash",
                 Name = "Telkar",
                 Email = "Akash@gmail.com",
                 Phone="1234598736",
                 Website ="Test.com",
                 Address = new AddressInfo
                 {
                     Street="wakad",
                     Suite="maharashtra",
                     City="Pune",
                     ZipCode="12345",
                     Geo = new GeoInfo
                     {
                         Lat=-40.32,
                         Lng= -31.90
                     },

                 },
                Company = new CompanyInfo
                {
                    CatchPhrase = "Test",
                    Name = "Persistent",
                    Bs = "Test1"
                },
             },
         };
        }

        public static List<UserDetails> GetEmptyUserData()
        {
            return new List<UserDetails>();
        }
        public static UserDetails NewUserData()
        {
            return new UserDetails
            {
                Id = 1,
                UserName = "Mruna",
                Name = "Telkar",
                Email = "Amruna@gmail.com",
                Phone = "1234598736",
                Website = "Test.com",
                Address = new AddressInfo
                {
                    Street = "kothrud",
                    Suite = "maharashtra",
                    City = "Pune",
                    ZipCode = "123459",
                    Geo = new GeoInfo
                    {
                        Lat = -40.37,
                        Lng = -31.99
                    },

                },
                Company = new CompanyInfo
                {
                    CatchPhrase = "Testing",
                    Name = "IBM",
                    Bs = "Testing1"
                },
            };
        }
        public static UserDetails UserDataById(int userId)
        {
            return new UserDetails
            {
                Id = 1,
                UserName = "Mruna",
                Name = "Telkar",
                Email = "Amruna@gmail.com",
                Phone = "1234598736",
                Website = "Test.com",
                Address = new AddressInfo
                {
                    Street = "kothrud",
                    Suite = "maharashtra",
                    City = "Pune",
                    ZipCode = "123459",
                    Geo = new GeoInfo
                    {
                        Lat = -40.37,
                        Lng = -31.99
                    },

                },
                Company = new CompanyInfo
                {
                    CatchPhrase = "Testing",
                    Name = "IBM",
                    Bs = "Testing1"
                },
            };
        }
    }
}

