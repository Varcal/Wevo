using Wevo.Dominio.Entidades;
using Wevo.NucleoCompartilhado.Validacoes;
using Wevo.NucleoCompartilhado.Validacoes.Base;

namespace Wevo.Dominio.Scopes
{
    public static class ClienteScopes
    {
        public static bool CriarSeEstiverValido(this Cliente cliente)
        {
            return GarantirQue.EstaValido(
                ValidarSe.NaoEstaNulo(cliente.Nome, "Nome é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Cpf, "CPF é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Email, "E-mail é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Telefone, "Telefone é obrigatório"),
                ValidarSe.DataValida(cliente.DataNascimento, "Data é obrigatória"),
                ValidarSe.MaiorIgualQue(0, (int)cliente.Sexo, "Sexo é obrigatório")
            );


        }

        public static bool AlterarSeEstiverValido(this Cliente cliente)
        {
            return GarantirQue.EstaValido(
                ValidarSe.MaiorQue(0, cliente.Id, "Código do cliente obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Nome, "Nome é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Cpf, "CPF é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Email, "E-mail é obrigatório"),
                ValidarSe.NaoEstaNulo(cliente.Telefone, "Telefone é obrigatório"),
                ValidarSe.DataValida(cliente.DataNascimento, "Data é obrigatória"),
                ValidarSe.MaiorIgualQue(0, (int)cliente.Sexo, "Sexo é obrigatório")
            );
        }
    }
}
