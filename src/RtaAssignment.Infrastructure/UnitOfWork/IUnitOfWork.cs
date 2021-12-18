using System;

namespace RtaAssignment.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}