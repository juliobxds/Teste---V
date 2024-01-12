using Teste___V.Models;

namespace Teste___V.ViewModels {
    public class ClienteAtualizarViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public virtual EndereçoAtualizarViewModel Endereco { get; set; }



    }
}
