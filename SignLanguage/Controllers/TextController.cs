using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SignLanguage.Models;
using SignLanguage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class TextController : ControllerBase
    {
        private readonly IMongoCollection<Text> _texts;
        // ITextBL TextBL;

        private readonly TextService _TextService;
      






        public TextController(TextService TextService)
        {
            _TextService = TextService;
        
        }

        // GET: api/<TextController>
        [HttpGet]
        public List<Text> Get()
        {

            return _TextService.Get();
        }
        //public Task<List<Text>>Get()
        //{
        //   // TextBL.
        //    List<Text> texts;
        //    texts =return _texts.Find(emp => true).ToList();
        //    return texts;
        //}

        // GET api/<TextController>/5
        [HttpGet("{id}")]
        public ActionResult<Text> Get(int id)
        {
            var txt = _TextService.Get(id);

            if (txt == null)
            {
                return NotFound();
            }

            return Ok(txt);
        }
        //public Text Get(int id)
        //{
        // return _texts.Find<Text>(txt => txt.TextId == id).FirstOrDefault();
        //}

        // POST api/<TextController>
        [HttpPost]
        public void Post([FromBody] string str)
        {
            
        }




        // PUT api/<TextController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TextController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}







