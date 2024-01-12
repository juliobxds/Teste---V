using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste___V.Data.Map;
using Teste___V.Models;
using Teste___V.ViewModels;

namespace Teste___V.Data {
    public class TesteDBContext : DbContext {

        public TesteDBContext(DbContextOptions<TesteDBContext> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            if (!options.IsConfigured) {
                options.UseSqlServer("DataBase");
            }
        }
        public TesteDBContext() : base() { }
        public virtual DbSet<ClienteM> Cliente { get; set; }
        public virtual DbSet<EndereçoM> Endereço { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EndereçoMap());
            base.OnModelCreating(modelBuilder);

        }
    }
        }
