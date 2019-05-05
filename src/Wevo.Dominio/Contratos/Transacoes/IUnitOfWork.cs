namespace Wevo.Dominio.Contratos.Transacoes
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
