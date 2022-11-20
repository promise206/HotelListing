using AutoMapper;
using HotelListing.API.DTOs;
using HotelListing.API.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        public HotelController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels() {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var result = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(hotels);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong {nameof(GetHotels)}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(x=>x.Id == id);
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong {nameof(GetHotel)}");
                return StatusCode(500);
            }
        }
    }
}
