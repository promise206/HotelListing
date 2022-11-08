using HotelListing.API.Data;
using HotelListing.API.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelListing.API.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public bool IsDisposed;
        private readonly DatabaseContext _Context;
        private IDbContextTransaction _dbContextTransaction;
        private IHotelRepository _hotelRepository;
        private ICountryRepository _countryRepository;
        public UnitOfWork(DatabaseContext context)
        {
            _Context = context;
        }
        public ICountryRepository Countries => _countryRepository?? new CountryRepository(_Context);

        public IHotelRepository Hotels => _hotelRepository?? new HotelRepository(_Context);

        public async Task CreateTransaction()
        {
            _dbContextTransaction = await _Context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContextTransaction.CommitAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task Rollback()
        {
            await _dbContextTransaction?.RollbackAsync();
            await _dbContextTransaction.DisposeAsync();
        }

        public async Task Save()
        {
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
