using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class ScopeClaim 
    { 
        public int Id { get; set; }
        public bool AlwaysIncludeInIdToken { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}