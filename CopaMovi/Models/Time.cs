using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace CopaMovi.Models
{
    [Table("T_TIME")]
    public class Time
    {
        [Key]
        public int TIMEID { get; set; }
        [Required]
        public string NOME_EQUIPE { get; set; }
        [Required]
        public string TIPO_TIME { get; set; }
        [Required]
        public string SEXO_TIME { get; set; }
        [Required]
        public string CAPITAO_DO_TIME { get; set; }
     
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Digite um  email válido.")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }
        [Required]
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##)####-#####}")]
        public string  TELEFONE { get; set; }
        [Required]
        [StringLength(300)]
        [Column("INSTITUICAO",TypeName ="VARCHAR")]
        public string Instituicao { get; set; }
        
    }
}