using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste___V.Data;
using Teste___V.Models;
using Teste___V.Repositorios.Interfaces;
using Teste___V.ViewModels;

namespace Teste___V.Repositorios {
    public class EndereçoRep : IEndereço {
        private readonly TesteDBContext _dBContext;

        public EndereçoRep(TesteDBContext testeDBContext) {
            _dBContext = testeDBContext;
        }
        public async Task<EndereçoViewModel> Adicionar(EndereçoViewModel endereço) {
            await _dBContext.AddAsync(endereço);
            _dBContext.SaveChanges();

            return endereço;
        }

        public async Task<bool> Apagar(int id) {
            EndereçoM buscarPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID: {id} nao foi encontrado");
            _dBContext.Endereço.Remove(buscarPorId);
            _dBContext.SaveChanges();
            return true;
        }

        public async Task<EndereçoM> Atualizar(EndereçoAtualizarViewModel endereço, int id) {

            EndereçoM buscarPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID: {id} nao foi encontrado");
            //buscarPorId.Id = endereço.Id;
            buscarPorId.NomeDaRua = endereço.NomeDaRua;
            buscarPorId.NumeroDaRua = endereço.NumeroDaRua;
            buscarPorId.Bairro = endereço.Bairro;
            buscarPorId.PontoDeReferencia = endereço.PontoDeReferencia;
            
            

            _dBContext.Endereço.Update(buscarPorId);
            _dBContext.SaveChanges();

            return buscarPorId;
        }

        public async Task<EndereçoM> BuscarPorId(int id) {
            return await _dBContext.Endereço.FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<List<EndereçoM>> Endereços() {
            return await _dBContext.Endereço.ToListAsync();
        }
    }
    }
