using SimulaCredito.Data.VO;
using SimulaCredito.Models;

namespace SimulaCredito.Data.Converter.Implementations
{
    public class ClienteConverter : IParser<ClienteVO, Cliente>, IParser<Cliente, ClienteVO>
    {
        public Cliente Parse(ClienteVO origin)
        {
            if (origin == null) return null;

            return new Cliente
            {
                Id = origin.Id,
                Celular = origin.Celular,
                CPF = origin.CPF,
                Financiamentos = origin.Financiamentos,
                Nome = origin.Nome,
                UF = origin.UF,
                Ativo = origin.Ativo
            };
        }

        public List<Cliente> Parse(List<ClienteVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public ClienteVO Parse(Cliente origin)
        {
            if (origin == null) return null;

            return new ClienteVO
            {
                Id = origin.Id,
                Celular = origin.Celular,
                CPF = origin.CPF,
                Financiamentos = origin.Financiamentos,
                Nome = origin.Nome,
                UF = origin.UF,
                Ativo = origin.Ativo
            };
        }

        public List<ClienteVO> Parse(List<Cliente> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
