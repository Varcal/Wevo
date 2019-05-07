using System;
using System.ComponentModel.DataAnnotations;

namespace Wevo.WebSite.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Sexo é obrigatório")]
        public Sexo Sexo { get; set; }
        [Required(ErrorMessage = "Data Nascimento é obrigatório")]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
