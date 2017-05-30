using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ServerMVC.Confg
{
    public class ConsegUsers
    {
        public static List<InMemoryUser> Get()
        {
            ServerMVC.Context.dbContext db = new ServerMVC.Context.dbContext();

            var resultUser = db._User.ToList();
                  
            List<InMemoryUser> InUser = new List<InMemoryUser>();
            foreach (var item in resultUser)
            {
                var InUserMemory = new InMemoryUser
                {
                    Username = item.Username,
                    Password = item.Password,
                    Subject = item.Subject,
                    Claims = new[] {
                        new System.Security.Claims.Claim(Constants.ClaimTypes.GivenName, "Paulo"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.FamilyName, "Linx"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.ClientId, item.Id.ToString()),
                            new System.Security.Claims.Claim(Constants.ClaimTypes.Scope, "roles"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Role, "Admin"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Role, "Sivic"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Role, "Area")
                    }
                };
                InUser.Add(InUserMemory);
            }

            return InUser;
        }
    }
}