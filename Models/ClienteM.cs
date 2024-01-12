using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teste___V.Data;

namespace Teste___V.Models {
    public class ClienteM {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Celular { get; set; }
        public int IdEndereco { get; set; }
        public virtual EndereçoM Endereco { get; set; }
    }
}

      
   