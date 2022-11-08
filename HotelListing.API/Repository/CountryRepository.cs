using HotelListing.API.Data;
using HotelListing.API.IRepository;

namespace HotelListing.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
