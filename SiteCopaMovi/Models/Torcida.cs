using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiteCopaMovi.Models
{
    [Table("T_TORCIDA")]
    public class Torcida
    {
        [Key]
        public int TORCIDA_ID { get; set; }
        public string TORCIDA_NOME { get; set; }
        public string RG { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int TIMEID { get; set; }
        [ForeignKey("TIMEID")]
        public Time Time { get; set; }
    }
}