using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Confg
{
    public class ConsegClients
    {
        public static List<Client> Get()
        {
            LinxServerAuthentication.Context.dbContext db = new LinxServerAuthentication.Context.dbContext();
            
            Client clients = new Client();
            List<Client> Listclients = new List<Client>();
            var ResultClients = db._Client.ToList();

            List<string> liststring = db._Scope.Select(d => d.Name).ToList<string>();

            foreach (var item in ResultClients)
            {
                //var clientid = db._ClientSecret.Where(d => d.Client.Id == item.Id).Select(d => d.Value.ToString()).SingleOrDefault().ToString();
                //var Urli = db._ClientRedirectUri.Where(d => d.Client.Id == item.Id).Select(d => d.Uri.ToString()).Single();
                //var Urlo = db._ClientPostLogoutRedirectUri.Where(d => d.Client.Id == item.Id).Select(d => d.Uri.ToString()).Single();

                List<string> ListSt = db._ClientScope.Where(d => d.Client.Id == item.Id).Select(d => d.Scope).ToList<string>();

                if (item.ClientId == "Linx" || item.ClientId == "ConsegRouter" || item.ClientId == "AdminConseg")
                {

                    clients = new Client
                    {
                        ClientName = item.ClientName,
                        ClientId = item.ClientId,
                        Enabled = true,
                        RequireConsent = item.RequireConsent,
                        Flow = (Flows)item.Flow,
                        ClientSecrets = new List<Secret> {
                        new Secret(db._ClientSecret.Where(d=>d.Client.Id == item.Id).Select(d=>d.Value.ToString()).Single().ToString())
                    },
                        AbsoluteRefreshTokenLifetime = 86400,
                        SlidingRefreshTokenLifetime = 43200,
                        RefreshTokenUsage = TokenUsage.OneTimeOnly,
                        RefreshTokenExpiration = TokenExpiration.Sliding,
                        RedirectUris = new List<string>
                    {
                       db._ClientRedirectUri.Where(d=>d.Client.Id == item.Id).Select(d=>d.Uri.ToString()).Single(),
                    },
                        PostLogoutRedirectUris = new List<string>
                    {
                        db._ClientPostLogoutRedirectUri.Where(d=>d.Client.Id == item.Id).Select(d=>d.Uri.ToString()).Single(),
                    },
                        AllowedScopes = ListSt
                    };
                    Listclients.Add(clients);
                }
              
               
            }
            return Listclients;

        }
        
      
    }
}
