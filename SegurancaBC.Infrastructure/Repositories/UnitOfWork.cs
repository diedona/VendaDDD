using SegurancaBC.Domain.Repositories;
using SegurancaBC.Infrastructure.Connection;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SegurancaBC.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _Connection;
        private bool disposedValue;
        private IDbTransaction _Transaction;
        private IUsuarioRepository _UsuarioRepository;

        public UnitOfWork(IConnectionData connection)
        {
            _Connection = new SqlConnection(connection.ConnectionString);
        }

        public void Begin()
        {
            _Transaction = _Connection.BeginTransaction();
        }

        public void Commit()
        {
            _Transaction.Commit();
            Dispose();
        }

        public void RollBack()
        {
            _Transaction.Rollback();
            Dispose();
        }

        public IDbConnection Connection => _Connection;
        public IDbTransaction Transaction => _Transaction;

        #region [ IDisposable ]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects)

                    if (_Transaction != null)
                        _Transaction.Dispose();

                    _Transaction = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
