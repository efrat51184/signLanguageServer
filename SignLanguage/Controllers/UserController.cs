using BL;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using AutoMapper;
using DTO;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class userController : ControllerBase
    {
        IUserBL userBL;
        IMapper mapper;
        ILogger logger;

        public userController(IUserBL userBL, IMapper mapper, ILogger<WordController> logger)
        {
            this.userBL = userBL;
            this.mapper = mapper;
            this.logger = logger;


        }
        // GET: api/<userController>
        // [HttpGet]

        [HttpGet]
        [AllowAnonymous]
        
        //התממשקות לפייתון
        public string Get(string str)
        {
            //WebRequest request;
            //request = WebRequest.Create("http://127.0.0.1:9007/sentiment/?mystring=" + str);
            //WebResponse response = request.GetResponse();
            //string responseFromServer = string.Empty;
            //using (Stream dataStream = response.GetResponseStream())
            //{
            //    // Open the stream using a StreamReader for easy access.
            //    StreamReader reader = new StreamReader(dataStream);
            //    // Read the content.
            //    responseFromServer = reader.ReadToEnd();
            //    // Display the content.
            //    Console.WriteLine(responseFromServer);

            //}
            ////טיפול בתשובה שחזרה מהשרת
            //response.Close();
            //return responseFromServer;
            return "n";
        }

        // GET api/<userController>/5
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<User> Get([FromBody] UserDto user)
        
        {
            
            return await userBL.GetBL(user.UserEmail, user.UserPassword);
            //User u =await userBL.GetBL(email, password);
            //return mapper.Map<User, UserDto>(u);
        
        
        
        
        
        }

        // POST api/<userController>
        // POST api/<HomeController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<User> Post([FromBody] User user)
        {

            return await userBL.PostBL(user);
        }


        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
           


            userBL.PutBL(id, user);
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
