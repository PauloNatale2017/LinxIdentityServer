using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Repository.entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using IdentityServer3.Core.Models;

    [Table("RolesAccess")]
    public class RolesAccess
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}