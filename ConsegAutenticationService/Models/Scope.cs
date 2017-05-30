using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class ScopeI : IdentityServer3.Core.Models.Scope
    {
        [Key]
        public int Id { get; set; }
        public string Claim { get; set; }
        public  List<string> Claims { get; set; }              
        public  string ClaimsRule { get; set; }      
        public  string Description { get; set; }      
        public  string DisplayName { get; set; }       
        public  bool Emphasize { get; set; }      
        public  bool Enabled { get; set; }     
        public  bool IncludeAllClaimsForUser { get; set; }      
        public  string Name { get; set; }      
        public  bool Required { get; set; }     
        public  bool ShowInDiscoveryDocument { get; set; }    
        public  int Type { get; set; }
    }   
}