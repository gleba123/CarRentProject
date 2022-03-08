using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{
    [Route("ManagerPage")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        ManagerClass Manag = new ManagerClass();

        #region Get Functions
        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            var result = Manag.GetAllUsers();
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
                
            }
            else
            {
                return NotFound();
            }
        }
        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{UserTz}")]
        public IActionResult GetUserByTz(int UserTz)
        {
            var result = Manag.GetUserByTz(UserTz);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(Manag.GetAllCars());
        }


        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{carNum}")]
        public IActionResult GetCarsByNumber(int carNum)
        {
            var result = Manag.GetOrderById(carNum);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrders()
        {
            var result = Manag.GetAllOrders();
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("[action]/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var result = Manag.GetOrderById(orderId);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Post Functions
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostNewUser(UserTable value)
        {
            var result = Manag.PostNewUser(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //post function for New User

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostUserOrder(RentTable value)
        {
            var result = Manag.PostUserOrder(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //post function for New Order

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostCarTypeTable(CarType value)
        {

            var result = Manag.PostCarTypeTable(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
 
            }


        } //post function for New CarTypeTable

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostCarInfoTable(CarInfo value)
        {
            var result = Manag.PostCarInfoTable(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }


        } //post function for New CarInfoTable
        #endregion

        #region Put Functions
        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{orderNum}")]
        public IActionResult UpdateOrder(int orderNum, [FromBody] RentTable value)
        {
            var result = Manag.UpdateOrderInfo(orderNum, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }

        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{userTz}")]
        public IActionResult UpdateUserInfo(int userTz, [FromBody] UserTable value)
        {
            var result = Manag.UpdateUserInfo(userTz, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }


        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{carNum}")]
        public IActionResult UpdateCarsInfo(int carNum, [FromBody] CarInfo value)
        {
            var result = Manag.UpdateCarsInfo(carNum, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }

        // PUT api/<ManagerController>/5
        [HttpPut("[action]/{carNum}")]
        public IActionResult UpdateCarsType(int carNum, [FromBody] CarType value)
        {
            var result = Manag.UpdateCarsType(carNum, value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }
        #endregion

        #region Delete Functions
        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{userTz}")]
        public IActionResult DeleteUser(int userTz)
        {
            var result = Manag.DeleteUser(userTz);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{orderNum}")]
        public IActionResult DeleteOrder(int orderNum)
        {
            var result = Manag.DeleteOrder(orderNum);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{CarTypeNum}")]
        public IActionResult DeleteCarType(int CarTypeNum)
        {
            var result = Manag.DeleteCarType(CarTypeNum);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }


        // DELETE api/<ManagerController>/5
        [HttpDelete("[action]/{carNumInfo}")]
        public IActionResult DeleteCarInfo(int carNumInfo)
        {
            var result = Manag.DeleteCarInfo(carNumInfo);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }
        }

        #endregion
    }
}
