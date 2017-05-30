namespace LinxServerAuthentication.Repository.entidadesConsegs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PESSOAS")]
    public partial class PESSOA
    {   

        [Key]
        public int ID_PESSOA { get; set; }

        public int? ID_PROFISSAO { get; set; }

        [Required]
        [StringLength(50)]
        public string PESSOA_NOME { get; set; }

        [StringLength(50)]
        public string PESSOA_NOME_PAI { get; set; }

        [StringLength(50)]
        public string PESSOA_NOME_MAE { get; set; }

        public DateTime? PESSOA_DATA_NASCIMENTO { get; set; }

        [StringLength(15)]
        public string PESSOA_RG { get; set; }

        [StringLength(11)]
        public string PESSOA_CPF { get; set; }

        [StringLength(1)]
        public string PESSOA_SEXO { get; set; }

        [StringLength(255)]
        public string PESSOA_EMAIL1 { get; set; }

        [StringLength(255)]
        public string PESSOA_EMAIL2 { get; set; }

        [StringLength(255)]
        public string PESSOA_EMAIL3 { get; set; }

        public bool PESSOA_ATIVO { get; set; }
   
        //public virtual ICollection<MEMBRO> MEMBROS { get; set; }
    }
}
