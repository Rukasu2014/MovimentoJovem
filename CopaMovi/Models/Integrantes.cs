using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaMovi.Models
{
    [Table("T_INTEGRANTES")]
    public class Integrantes
    {
        [Key]
        public int JOGADORESID { get; set; }
        public string NOME_JOGADORES { get; set; }
        public string RG { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int TIMEID { get; set; }

        [ForeignKey("TIMEID")]
        public Time Time { get; set; }
    }
}