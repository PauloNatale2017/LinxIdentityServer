using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class User : InMemoryUser
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<string> Claims { get; set; }    
        public bool Enabled { get; set; }    
        public string Password { get; set; }    
        public string Provider { get; set; }     
        public string ProviderId { get; set; }    
        public string Subject { get; set; }  
        public string Username { get; set; }
        
    }
}