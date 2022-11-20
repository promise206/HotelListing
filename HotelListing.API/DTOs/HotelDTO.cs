using HotelListing.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.DTOs
{
    public class HotelDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        
    }
}
