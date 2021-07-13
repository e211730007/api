using AutoMapper;
using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PropertyController : ControllerBase
    {
        IPropertyBL _ipropertyBL;
        IMapper _mapper;
        public PropertyController(IPropertyBL ipropertyBL, IMapper mapper)
        {
            _mapper = mapper;
            _ipropertyBL = ipropertyBL;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Property>> getOrders(int userId)
        {
            Property property = await _ipropertyBL.getOrders(userId);
            if (property == null)
                return NoContent();
            else
                return Ok(_mapper.Map<Property, Property>(property));
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Property> Post([FromBody] Property property)
        {
            // Property p = _mapper.Map<OrdersDTO, Orders>(order);
            
         //   order = _mapper.Map<Property, OrdersDTO>(o);
            return await _ipropertyBL.Post(property)
        }
    }
}
