using System.Collections.Generic;
using System.Threading.Tasks;
using Teste___V.Models;
using Teste___V.ViewModels;

namespace Teste___V.Repositorios.Interfaces {
    public interface IEndereço {
        Task<List<EndereçoM>> Endereços();
        Task<EndereçoM> BuscarPorId(int id);
        Task<EndereçoViewModel> Adicionar(EndereçoViewModel endereço);
        Task<EndereçoM> Atualizar(EndereçoAtualizarViewModel endereço, int id);
        Task<bool> Apagar(int id);
    }
}
