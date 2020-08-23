using Infrastructure.Connection;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IServiceProvider _ServiceProvider;
        private bool disposedValue;

        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IConnectionData connection, IServiceProvider serviceProvider)
        {
            Connection = new SqlConnection(connection.ConnectionString);
            _ServiceProvider = serviceProvider;
        }

        #region [ IUnitOfWork ]

        public void Begin()
        {
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void RollBack()
        {
            Transaction.Rollback();
            Dispose();
        }

        public TRepositorio PegarRepositorio<TRepositorio>() where TRepositorio : IRepository
        {
            Type tipoRepositorio = typeof(TRepositorio);
            return (TRepositorio)_ServiceProvider.GetService(tipoRepositorio);
        }

        #endregion

        #region [ IDisposable ]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects)

                    if (Transaction != null)
                        Transaction.Dispose();

                    Transaction = null;
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
