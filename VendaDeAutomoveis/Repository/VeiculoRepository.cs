using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.Repository
{
    public class VeiculoRepository : RepositoryBase<Veiculo>
    {
        public VeiculoRepository(ContextGDCars context)
            : base(context)
        {
        }

        public override void Editar(Veiculo obj)
        {
            var domain = Mapper.Map<Veiculo, GDC_Veiculos>(obj);

            _context.Veiculos.Attach(domain);
            var entry = _context.Entry(domain);
            entry.State = System.Data.Entity.EntityState.Modified;
            SaveChange();
        }

        public void Excluir(Guid id)
        {
            var domain = Mapper.Map<Veiculo, GDC_Veiculos>(ObterPorId(id));

            _context.Veiculos.Remove(domain);
            SaveChange();
        }

        public override Veiculo ObterPorId(Guid id)
        {
            var domain = Mapper.Map<GDC_Veiculos, Veiculo>(_context.Veiculos.Where(b => b.Id == id).FirstOrDefault());
            return domain;
        }

        public override IList<Veiculo> ObterTodos()
        {
            var sql = "SELECT * FROM GDC_Veiculos ";

            return _context.Database.Connection.Query<Veiculo>(sql)
                .OrderBy(c => c.Data_Cadastro)
                .ThenBy(c => c.ModeloVeiculo)
                .ToList();
        }
    }
}