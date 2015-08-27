using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiteCopaMovi.Models
{
    [Table("T_PATROCINADOR")]
    public class Patrocinador
    {
        [Key]
        public int PATROCIONADORID { get; set; }
        [Required]
        public string NOME_EMPRESA { get; set; }
        [Required]
        public string TELEFONE_EMPRESA { get; set; }
        [Required]
        public string EMAIL_EMPRESA { get; set; }
        [Required]
        public string ENDERECO_EMPRESA { get; set; }
        [Required]
        public string TIPO_COTA { get; set; }
        [Required]
        public int QUANTIDADE { get; set; }
    }
}