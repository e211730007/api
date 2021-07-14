using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonController : ControllerBase
    {
      
        IPersonBL _personBL;
        ILogger<PersonController> _ilogger;
        IMapper _mapper;

        public PersonController(IPersonBL ipersonBL)
        {
            _personBL = ipersonBL;
            
        }


        //[HttpGet("{login}/{password}")]
        //public async Task<ActionResult<Person>> getUser(string login, string password)
        //{
        //    try
        //    {
               
        //        Person use = await _personBL.getUser(login, password);
        //        _ilogger.LogInformation($"login attempted with user name, {login} and password {password}");
        //       // throw new Exception("good!!!!!!!!!!!!!!!");
        //        if (use == null)
        //            return NoContent();
        //        else
        //            return Ok(use);
        //    }
        //    catch (Exception e)
        //    {
        //        _ilogger.LogError(e.Message + e.StackTrace);
        //        throw;
        //    }
        //}

   //    [HttpPost]
   //    public async Task<User> Post([FromBody] UserDTO user)
   //    {
   //        User user1 = await _iuserBL.Post(user);
   //        return _mapper.Map<UserDTO, User>(user1);
   //    }
   //
   //    [HttpPut("{id}")]
   //    public async Task<User> Put(int id, [FromBody] UserDTO userToUpdate)
   //    {
   //        User user =  await _iuserBL.Put(id, userToUpdate);
   //        return _mapper.Map<UserDTO,User>(user);
   //    }


        //// POST: api/users
        //[HttpPost]
        //public async Task Post([FromBody] Person person)
        //{
        //   // User user = _mapper.Map<UserDTO, User>(dtou);
        //    await _personBL.Post(person);
        //    //return user;
        //}



        //// PUT api/<myController>/5
        //[HttpPut("{id}")]
        //public async Task<Person> Put(int id, [FromBody] Person personToUpdate)
        //{
        //    //User user = _mapper.Map<UserDTO, User>(dtouToUpdate);
        //    return await _personBL.Put(id, personToUpdate);

        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

       
    }
}
