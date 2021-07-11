using AutoMapper;
using BL;
using DL;
using DTO;
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
        ICategoryBL _icategoryBL;
        IMapper _mapper;
        public RoleController(ICategoryBL categoryBL,IMapper mapper)
        {
            _mapper = mapper;
            _icategoryBL = categoryBL;
        }

      
        [HttpGet]
        public async Task<List<CategoryTableDTO>> getCategory()
        {
            
           List<CategoryTable> category = await _icategoryBL.getCategory(); 
            if (category == null)
                return null;
            else
                return _mapper.Map<List<CategoryTable>,List< CategoryTableDTO>>(category);
        }
    }
}
