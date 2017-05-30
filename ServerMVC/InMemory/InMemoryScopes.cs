using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMVC
{
    public class InMemoryScopes
    {

        public static IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.OfflineAccess,
                    new Scope
                    {
                        Name = "read",
                        DisplayName = "Leitura",
                        Type = ScopeType.Resource,
                        Emphasize = false,
                        AllowUnrestrictedIntrospection = true,
                        ScopeSecrets = new List<Secret> { new Secret("secret".Sha256()) }
                    },
            };

        }


    }
}