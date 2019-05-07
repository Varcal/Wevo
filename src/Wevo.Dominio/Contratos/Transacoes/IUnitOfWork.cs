using System;

namespace Wevo.Dominio.Contratos.Transacoes
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
