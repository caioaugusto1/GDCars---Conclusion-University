namespace VendaDeAutomoveis.Repository.ConnectionContext.Interfaces
{
    public interface ILoginRepository : IRepositoryBase<GDC_Logins>
    {
        GDC_Logins BuscarPorEmail(string email);

        GDC_Logins AutenticarAcesso(string email, string senha);
    }
}
    