using AutoMapper;
using BL;
using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleBL _iroleBL;
        IMapper _mapper;
        public RoleController(IRoleBL iroleBL, IMapper mapper)
        {
            _mapper = mapper;
            _iroleBL = iroleBL;
        }

      
        [HttpGet]
        public async Task<List<Role>> getRole()
        {
            
           List<Role> category = await _iroleBL.getRole(); 
            if (category == null)
                return null;
            else
                return _mapper.Map<List<Role>,List<Role>>(category);
        }
    }
}
