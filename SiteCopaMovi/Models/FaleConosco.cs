using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiteCopaMovi.Models
{
    [Table("T_FALECONOSCO")]
    public class FaleConosco
    {
        public string Nome { get; set; }
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Digite um  email válido.")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string COMISSAO { get; set; }
        [Column("MENSAGEM",TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string MENSAGEM { get; set; }
    }
}