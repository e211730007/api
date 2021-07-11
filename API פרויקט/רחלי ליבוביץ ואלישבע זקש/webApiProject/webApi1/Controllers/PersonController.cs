using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using DTO;
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
      
        IUserBL _iuserBL;
        ILogger<PersonController> _ilogger;
        IMapper _mapper;

        public PersonController(IUserBL iuserBL, ILogger<PersonController> logger, IMapper mapper )
        {
            _iuserBL = iuserBL;
            _ilogger = logger;
            _mapper = mapper;
        }


        [HttpGet("{login}/{password}")]
        public async Task<ActionResult<UserDTO>> getUser(string login, string password)
        {
            try
            {
               
                User use = await _iuserBL.getUser(login, password);
                _ilogger.LogInformation($"login attempted with user name, {login} and password {password}");
               // throw new Exception("good!!!!!!!!!!!!!!!");
                if (use == null)
                    return NoContent();
                else
                    return Ok(_mapper.Map<User,UserDTO>(use));
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }

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


        // POST: api/users
        [HttpPost]
        public async Task Post([FromBody] UserDTO dtou)
        {
            User user = _mapper.Map<UserDTO, User>(dtou);
            await _iuserBL.Post(user);
            //return user;
        }



        // PUT api/<myController>/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] UserDTO dtouToUpdate)
        {
            User user = _mapper.Map<UserDTO, User>(dtouToUpdate);
            return await _iuserBL.Put(id, user);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }
}
