using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class Cars : ControllerBase
    {
        private readonly CarsService _carsService;

        public Cars(CarsService carsService)
        {
            this._carsService = carsService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                var cars = await _carsService.GetCars();
                return Ok(cars);

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            try
            {
                var car = await _carsService.GetCar(id);
                return Ok(car);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCar([FromBody] CarDetailModel model)
        {
            try
            {
                await _carsService.AddCar(model);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDetailModel model)
        {
            try
            {
                await _carsService.UpdateCar(model);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carsService.DeleteCar(id);
                return Ok();
            } catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

    }
}
