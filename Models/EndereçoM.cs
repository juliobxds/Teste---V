using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teste___V.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste___V.Models {
    public class EndereçoM {
        public int Id { get; set; }
        public string NomeDaRua { get; set; }
        public int NumeroDaRua { get; set; }
        public string Bairro { get; set; }
        public string PontoDeReferencia { get; set; }
        public int IdCliente { get; set; }
        public virtual ClienteM Cliente { get; set; } // ciclos infinitos nao sao legais (nunca fazer)

    }
}