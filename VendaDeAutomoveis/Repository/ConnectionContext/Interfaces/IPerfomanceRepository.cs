using System;

namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface IPerfomanceRepository : IRepositoryBase<GDC_Perfomances>
    {
        void InserirPasso1Roda(Guid id, Guid idCliente, Guid idRoda, double ValorTotal);

        void InserirPasso2Cor(Guid id, Guid idCorVeiculo);

        void InserPasso3Banco(Guid id, Guid idBanco);
    }
}
