using VendaDeAutomoveis.DAO.ConnectionContext;

namespace VendaDeAutomoveis.Repository
{
    public class RepositoryBase<DBEntity>
        where DBEntity : class
    {
        protected readonly GDCarsContext _context;

        string connectionString = GDCarsConnectionString.Connection;

        public RepositoryBase(GDCarsContext context)
        {
            _context = context;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}