using System.Collections.Generic;
using System.Threading.Tasks;
using Teste___V.Models;
using Teste___V.ViewModels;

namespace Teste___V.Repositorios.Interfaces {
    public interface IClienteRepository 
    {
        Task<List<ClienteM>> TodosClientes();
        Task<ClienteM> BuscarPorId(int id);
        Task<ClienteViewModel> Adicionar(ClienteViewModel cliente);
        Task<ClienteM> Atualizar(ClienteAtualizarViewModel cliente);
        Task<bool> Apagar(int id);
        
    }
}
