using System;
using System.Transactions;

namespace RtaAssignment.Infrastructure.UnitOfWork
{
    public class TransactionScopeUnitOfWork : IUnitOfWork
    {
        private readonly TransactionScope _transactionScope;
        private bool _disposed;

        public TransactionScopeUnitOfWork()
        {
            _transactionScope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions
                    {IsolationLevel = IsolationLevel.ReadCommitted, Timeout = TransactionManager.MaximumTimeout},
                TransactionScopeAsyncFlowOption.Enabled
            );
        }

        public void Commit()
        {
            _transactionScope.Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _transactionScope.Dispose();

            _disposed = true;
        }
    }
}