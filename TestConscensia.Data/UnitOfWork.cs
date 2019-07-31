using System;
using TestConscensia.Data.Base;
using TestConscensia.Data.Contexts;
using TestConscensia.Data.Entities;
using TestConscensia.Data.Repositories;

namespace TestConscensia.Data
{
    public class UnitOfWork : IDisposable
    {
        private IDbContext _context;
        private IRepository<ReportCodeEntity> _reportCodeRepository;
        
        public UnitOfWork()
        {
            _context = new TestDbContext();
        }

        public IRepository<ReportCodeEntity> TypeRepository
        {
            get
            {
                if (_reportCodeRepository == null) _reportCodeRepository = new ReportCodeRepository(_context);
                return _reportCodeRepository;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}