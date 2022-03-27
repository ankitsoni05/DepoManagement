using AutoMapper;
using DBAccess.UnitOfWork.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAM = DBAccess.DataAccessModels;
using DMM = DriversManagement.Models;

namespace DriversManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriversController(ILogger<DriversController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAllDriversAsync()
        {
            var drivers = _mapper.Map<IEnumerable<DMM.Driver>>(await _unitOfWork.Drivers.GetAllAsync());
            return Ok(drivers);
        }
    }
}
