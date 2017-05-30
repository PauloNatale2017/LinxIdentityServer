using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMVC.Repository.entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using IdentityServer3.Core.Models;

    [Table("UserClaimsConseg")]
    public class UserClaimsConseg
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Secret { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public List<string> Roles { get; set; }
    }
}