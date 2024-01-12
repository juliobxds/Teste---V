using Teste___V.Models;

namespace Teste___V.ViewModels {
    public class ClienteViewModel {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public virtual EndereçoViewModel Endereco { get; set; }
    }
}
