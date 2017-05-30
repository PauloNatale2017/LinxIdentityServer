using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace LinxServerAuthentication
{
    public class InMemoryUsers
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
        {
            new InMemoryUser
            {
                Subject = "GUIDS",
                Username = "rafael.miceli@oauth.com",
                Password = "123456",
                //Pequena mudança no nome do Claims comparado ao IdentityServe3
                Claims = new []
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Rafael Miceli")
                }
            }
        };
        }
    }
}