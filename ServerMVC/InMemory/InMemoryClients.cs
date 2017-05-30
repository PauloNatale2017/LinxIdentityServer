using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMVC
{
    public class InMemoryClients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
               new Client
                        {
                            ClientId = "AdminConseg",
                            ClientName = "AdminConseg",
                            ClientSecrets = new List<Secret>
                            {
                                new Secret("AdminConseg".Sha256())
                            },
                            Flow = Flows.Implicit,

                            AllowedScopes  = new List<string>
                            {
                                    StandardScopes.OpenId.Name,
                                    StandardScopes.Profile.Name,
                                    "read"
                            },
                            RedirectUris = new List<string>
                            {
                                "http://localhost:61218/"
                            },
                            PostLogoutRedirectUris = new List<string>
                            {
                                 "http://localhost:61218/"
                            },
                            Enabled = true
                        }
            };
        }
    }
}