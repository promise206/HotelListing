using HotelListing.API.Data;
using HotelListing.API.IRepository;

namespace HotelListing.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(DatabaseContext context): base(context)
        {

        }
    }
}
