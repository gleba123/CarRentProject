using DLL_Ver6;
using DLL_Ver6.MainClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Ver6.Controllers
{
    [ApiController]
    [Route("UserCarPage")]
    public class UserController : ControllerBase
    {
        UserClass userClass = new UserClass();


        #region Get Function
        // GET: api/<UserController>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCars()
        {
            return Ok(userClass.GetAllCars());
        } //function that Send all the cars to the Front-End

        // GET api/<UserController>/5
        [HttpGet]
        [Route("[action]/{carNum}")]
        public IActionResult GetCarsByNumber(int carNum)
        {
            if (carNum == 0)
            {
                return NotFound("Invalid license number");
            }
            return Ok(new UserClass().GetCarsByNumber(carNum));
        } //function that send the spacific car to the Front-End

        [HttpGet]
        [Route("[action]/{OrderId}")] //function that send the spacific order to the Front - End

        public IActionResult GetOrderById(int OrderId)
        {
            var result = userClass.GetOrderById(OrderId);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }



        } //function that send the spacific user to the Front-End 

        [HttpGet]
        [Route("[action]/{userTz}")] //function that send the spacific order to the Front - End

        public IActionResult ShowUserOrder(int userTz)
        {
            var result = userClass.ShowUserOrder(userTz);
            if (result.IsSuccess)
            {
                return Ok(result.RespObject);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[action]/{NickName}/{Password}")] //function for LogIn
        public IActionResult Login(string NickName, string Password)
        {
            var logIn = userClass.LogIn(NickName, Password);
            if (logIn.IsSuccess == true)
            {
                return Ok(logIn.RespObject);
            }
            else
            {
                return NotFound(logIn.IsSuccess);
            }
        } //function that send the spacific user to the Front-End

        #endregion

        #region Post Function
        // POST api/<UserController>

        [HttpPost]
        [Route("[action]")] //Register function
        public IActionResult Register([FromBody] UserTable value)
        {

            var result = userClass.Register(value);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.error);
            }



        }
    


        [HttpPost]
        [Route("[action]")] //post function that send to the DB the infomation that the User entere's in the Front-End 
        public IActionResult NewUserOrder(RentTable value) //post function for New order
        {
            var result = userClass.PostUserOrder(value);
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
