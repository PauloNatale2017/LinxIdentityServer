using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class WelCome : CommonViewModel
    {

        public IEnumerable<LoginPageLink> AdditionalLinks { get; set; }       
        public bool AllowRememberMe { get; set; }     
        public AntiForgeryTokenViewModel AntiForgery { get; set; }      
        public string ClientLogoUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public IEnumerable<LoginPageLink> ExternalProviders { get; set; }
        public string LoginUrl { get; set; }
        public bool RememberMe { get; set; }
        public string Username { get; set; }

    }
}