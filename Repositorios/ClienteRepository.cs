using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste___V.Data;
using Teste___V.Models;
using Teste___V.Repositorios.Interfaces;
using Teste___V.ViewModels;

namespace Teste___V.Repositorios {
    public class ClienteRepository : IClienteRepository {
        private readonly TesteDBContext _dBContext;
        public ClienteRepository(TesteDBContext testeDBContext) {
            _dBContext = testeDBContext;
        }
        public async Task<List<ClienteM>> TodosClientes() {
            return await _dBContext.Cliente.Include(x => x.Endereco).ToListAsync();
        }
        public async Task<ClienteM> BuscarPorId(int id) {
            return await _dBContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ClienteViewModel> Adicionar(ClienteViewModel cliente) {

            ClienteM clienteM = new ClienteM() { Name = cliente.Name, Email = cliente.Email, Celular = cliente.Celular };
            EndereçoM endereco = new EndereçoM() {
                NomeDaRua = cliente.Endereco.NomeDaRua,
                Bairro = cliente.Endereco.Bairro,
                NumeroDaRua = cliente.Endereco.NumeroDaRua,
                PontoDeReferencia = cliente.Endereco.PontoDeReferencia,
            };
            clienteM.Endereco = endereco; 
            var clienteAdicionado = _dBContext.Cliente.Include(x => x.Endereco); // 
            _dBContext.SaveChanges(); 

            return cliente;

        }
        public async Task<ClienteM> Atualizar(ClienteAtualizarViewModel cliente) {
            

            ClienteM buscarPorId = await BuscarPorId(cliente.Id) ?? throw new Exception($"Usuario para o ID: {cliente.Id} nao foi encontrado");
            buscarPorId.Id = cliente.Id;
            buscarPorId.Name = cliente.Name;
            buscarPorId.Email = cliente.Email;
            buscarPorId.Celular = cliente.Celular;
            buscarPorId.Endereco = new EndereçoM() {
                NomeDaRua = cliente.Endereco.NomeDaRua,
                Bairro = cliente.Endereco.Bairro,
                NumeroDaRua = cliente.Endereco.NumeroDaRua,
                PontoDeReferencia = cliente.Endereco.PontoDeReferencia,
                 };

            _dBContext.Cliente.Update(buscarPorId);
            _dBContext.SaveChanges();

            return buscarPorId;
        }
        public async Task<bool> Apagar(int id) {

            ClienteM buscarPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID: {id} nao foi encontrado");
            _dBContext.Cliente.Remove(buscarPorId);
            _ = _dBContext.SaveChanges();
            return true; 
        }

        
    }
    }
