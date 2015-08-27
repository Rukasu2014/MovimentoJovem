using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaMovi.Models
{
    [Table("T_PATROCINADOR")]
    public class Patrocinador
    {
        [Key]
        public int PATROCIONADORID { get; set; }
        public string NOME_EMPRESA { get; set; }
        public string TELEFONE_EMPRESA { get; set; }
        public string TIPO_COTA { get; set; }

    }
}