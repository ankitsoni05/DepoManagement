﻿using AutoMapper;
using DBAccess.UnitOfWork.Contract;
using DriversManagement.Dtos;
using DriversManagement.Models;
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

        [HttpGet("getAllDrivers")]
        public async Task<IActionResult> GetAllDriversAsync()
        {
            var drivers = _mapper.Map<IEnumerable<DMM.Driver>>(await _unitOfWork.Drivers.GetAllAsync());
            if (drivers == null)
                return NotFound();
            return Ok(drivers);
        }

        [HttpGet("getDriver/{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = _mapper.Map<DMM.Driver>(await _unitOfWork.Drivers.GetAsync(id));
            if (driver == null)
                return NotFound();
            return Ok(driver);
        }

        [HttpPost("createDriver")]
        public async Task<IActionResult> CreateDriver(Driver driverDto)
        {
            var driver = _mapper.Map<DAM.Driver>(driverDto);
            await _unitOfWork.Drivers.AddAsync(driver);
            var result = await _unitOfWork.CompleteAsync();
            return Ok(_mapper.Map<DMM.Driver>(driver));
        }

        [HttpGet("getDropdownsData")]
        public async Task<IActionResult> dropDownsData()
        {
            var divisions = _mapper.Map<IEnumerable<DMM.Division>>(await _unitOfWork.Divisions.GetAllAsync());
            var depos = _mapper.Map<IEnumerable<DMM.Depo>>(await _unitOfWork.Depos.GetAllAsync());
            var DepoDivisonDropdowns = new DepoDivisonDropdowns()
            {
                depos = depos,
                divisions = divisions
            };
            return Ok(DepoDivisonDropdowns);
        }

        [HttpPost("addPayAttributes")]
        public async Task<IActionResult> AddPayAttributes(DriverPay driverPay)
        {
            var pAttributes = _mapper.Map<DAM.DriverPay>(driverPay);
            await _unitOfWork.payAttributes.AddAsync(pAttributes);
            var result = await _unitOfWork.CompleteAsync();
            return Ok(_mapper.Map<DMM.DriverPay>(pAttributes));
        }
    }
}
