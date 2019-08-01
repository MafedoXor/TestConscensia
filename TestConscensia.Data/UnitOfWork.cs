using System;
using TestConscensia.Data.Base;
using TestConscensia.Data.Contexts;
using TestConscensia.Data.Entities;
using TestConscensia.Data.Repositories;

namespace TestConscensia.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly IDbContext _context;

        private ReportCodeRepository _reportCodeRepository;
        private OfficeLocationRepository _officeLocationRepository;

        public UnitOfWork()
        {
            _context = new TestDbContext();
        }

        public ReportCodeRepository ReportCodeRepository
        {
            get
            {
                if (_reportCodeRepository == null)
                    _reportCodeRepository = new ReportCodeRepository(_context);

                return _reportCodeRepository;
            }
        }

        public OfficeLocationRepository OfficeLocationRepository
        {
            get
            {
                if (_officeLocationRepository == null)
                    _officeLocationRepository = new OfficeLocationRepository(_context);

                return _officeLocationRepository;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}