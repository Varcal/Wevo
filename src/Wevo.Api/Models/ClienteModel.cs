using System;
using Wevo.Dominio.Entidades;
using Wevo.Dominio.Enums;

namespace Wevo.Api.Models
{
    public sealed class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public ClienteModel()
        {
            
        }


        public ClienteModel(Cliente cliente)
        {

            Id = cliente.Id;
            Nome = cliente.Nome.ToString();
            Cpf = cliente.Cpf.ToString();
            Email = cliente.Email.ToString();
            Telefone = cliente.Telefone.ToString();
            Sexo = cliente.Sexo;
            DataNascimento = cliente.DataNascimento;

        }
    }
}
