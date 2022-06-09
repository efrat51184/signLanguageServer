using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]

    public class WordController : ControllerBase
    {
        IWordBL wordBL;
        IMapper mapper;
        ILogger logger;

        public WordController(IWordBL wordBL, IMapper mapper,ILogger<WordController> logger)
        {
            this.logger = logger;
            this.wordBL = wordBL;
            this.mapper = mapper;



        }
        // GET: api/<WordController>
        [HttpGet]
        public async Task<List<Word>> Get()
        {
      
            return await wordBL.GetBL();
        }

        // GET api/<WordController>/5
        [HttpGet("{categoryId}")]
        public async Task<List<Word>> Get(int categoryId)

        {
          

            List<Word> l = await wordBL.GetBL(categoryId);
            if (l != null)
                //return mapper.Map<List<Word>, List<WordDto>>(l);
                return l;
            return null;
        }

        // POST api/<WordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
