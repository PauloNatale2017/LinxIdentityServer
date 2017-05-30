using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Confg
{
    public class ConsegScopes
    {
        public static IEnumerable<Scope> Get()
        {
            LinxServerAuthentication.Context.dbContext db = new LinxServerAuthentication.Context.dbContext();

            var ResultScopes = db._Scope.ToList();

            List<Scope> scopp = new List<Scope>();

            foreach (var item in ResultScopes)
            {
                var scopps = new Scope
                {
                    Enabled = item.Enabled,
                    Name = item.Name,
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(item.ClaimsRule)
                     }
                };
                scopp.Add(scopps);
            }
            scopp.AddRange(StandardScopes.All);

            return (IEnumerable<Scope>)scopp;

        }
    }
}