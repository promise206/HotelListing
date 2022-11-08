using HotelListing.API.Data;

namespace HotelListing.API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository Countries { get; }
        IHotelRepository Hotels { get; }

        Task Commit();
        Task CreateTransaction();
        void Dispose();
        Task Rollback();
        Task Save();
    }
}
