namespace LinxServerAuthentication.Repository.entidadesConsegs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBROS")]
    public partial class MEMBRO
    {   
        [Key]
        public int ID_MEMBRO { get; set; }

        public int? ID_CONSEG { get; set; }

        public int ID_PESSOA { get; set; }

        public int? ID_CARGO_CONSEG { get; set; }

        public int? ID_CARGO_POLICIA { get; set; }

        public int? ID_COMANDO_SUPERIOR { get; set; }

        public int? ID_COMANDO { get; set; }

        public int? ID_BATALHAO { get; set; }

        public int? ID_COMPANIA { get; set; }

        public int? ID_DEPARTAMENTO { get; set; }

        public int? ID_SECCIONAL { get; set; }

        public int? ID_DELEGACIA { get; set; }

        public int? ID_NAL { get; set; }

        public int? ID_MOTIVO_EXCLUSAO { get; set; }

        public DateTime? MEMBRO_DATA_ENTRADA { get; set; }

        public DateTime? MEMBRO_DATA_SAIDA { get; set; }

        public DateTime? MEMBRO_DATA_FICHA { get; set; }

        public DateTime? MEMBRO_DATA_INCLUSAO { get; set; }

        public DateTime? MEMBRO_DATA_ALTERACAO { get; set; }

        [Required]
        [StringLength(1)]
        public string MEMBRO_TIPO { get; set; }

        [StringLength(255)]
        public string MEMBRO_LOGIN { get; set; }

        [StringLength(50)]
        public string MEMBRO_SENHA { get; set; }

        [StringLength(50)]
        public string MEMBRO_SENHA_SALT { get; set; }

        [StringLength(3)]
        public string MEMBRO_GRUPO { get; set; }

        [StringLength(2000)]
        public string MEMBRO_HISTORICO_ACOES { get; set; }

        [StringLength(2000)]
        public string MEMBRO_ELOGIOS { get; set; }

        [StringLength(8000)]
        public string MEMBRO_DESCRICAO_EXCLUSAO { get; set; }

        public bool MEMBRO_EXCLUIDO { get; set; }

        public bool MEMBRO_PRIMEIRO_LOGIN { get; set; }
     
        //public virtual ICollection<ACESSOS_CONSEG> ACESSOS_CONSEG { get; set; }

        public virtual PESSOA PESSOA { get; set; }
    }
}
