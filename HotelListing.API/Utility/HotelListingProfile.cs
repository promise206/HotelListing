using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTOs;

namespace HotelListing.API.Utility
{
    public class HotelListingProfile : Profile
    {
        public HotelListingProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
        }
    }
}
