using HotelListing.API.Data;

namespace HotelListing.API.DTOs
{
    public class CountryDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<HotelDTO> Countries { get; set; }

    }
}
