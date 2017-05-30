namespace LinxServerAuthentication.Repository.entidadesConsegs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACESSOS_CONSEG
    {
        [Key]
        public int ID_ACESSO { get; set; }

        public int? ID_MEMBRO { get; set; }

        [Required]
        [StringLength(15)]
        public string ACESSO_IP { get; set; }

        public DateTime ACESSO_DATA { get; set; }

        [Required]
        [StringLength(3)]
        public string ACESSO_PAGINA { get; set; }

        public virtual MEMBRO MEMBRO { get; set; }
    }
}
