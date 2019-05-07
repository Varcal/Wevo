using System;
using Microsoft.EntityFrameworkCore.Storage;
using Wevo.Dados.Contextos;
using Wevo.Dominio.Contratos.Transacoes;

namespace Wevo.Dados.Transacoes
{
    public sealed class UnitOfWork: IUnitOfWork
    {
        private readonly EfContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext db)
        {
            _db = db;
        }

        public void BeginTransaction()
        {
            _transaction = _db.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        #region IDisposable Support
        private bool _disposedValue; 

        void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                _transaction?.Dispose();
                _db?.Dispose();
            }

            _disposedValue = true;
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
