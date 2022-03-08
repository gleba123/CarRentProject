using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{

    [Route("EmployeePage")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        EmployeeClass emp = new EmployeeClass();

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(emp.GetAllCars());
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrders()
        {
            var result = emp.GetAllOrders();
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{carNumber}")]
        public IActionResult GetCarByNumber(int carNumber)
        {

            return Ok(emp.GetCarsByNumber(carNumber));
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var result = emp.GetOrderById(orderId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("[action]/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var result = emp.GetUserById(userId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[action]/{userTz}")] //function that send the spacific order to the Front - End

        public IActionResult ShowUserOrder(int userTz)
        {
            var result = emp.ShowUserOrder(userTz);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("[action]/{CarNum}")]
        public IActionResult EmployeeReturnCar(int CarNum, [FromBody] RentTable value)
        {
            var result = emp.EmployeeReturnCar(CarNum, value);
            if (result.IsSuccess)
            {
                return Ok();

            }
            else
            {
                return BadRequest(result.error);
            }
        }


        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
