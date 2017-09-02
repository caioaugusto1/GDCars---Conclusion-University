using VendaDeAutomoveis.DAO.ConnectionContext;

namespace VendaDeAutomoveis.Repository
{
    public class RepositoryBase<DBEntity>
        where DBEntity : class
    {
        protected readonly ContextGDCars _context;

        string connectionString = GDCarsConnectionString.Connection;

        public RepositoryBase(ContextGDCars context)
        {
            _context = context;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}