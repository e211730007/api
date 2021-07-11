using AutoMapper;
using BL;
using DTO;
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

    public class PropertiesController : ControllerBase
    {
        IOrdersBL _iOrdersBL;
        IMapper _mapper;
        public PropertiesController(IOrdersBL iOrdersBL,IMapper mapper)
        {
            _mapper = mapper;
            _iOrdersBL = iOrdersBL;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<OrdersDTO>> getOrders(int userId)
        {
            Orders order = await _iOrdersBL.getOrders(userId);
            if (order == null)
                return NoContent();
            else
                return Ok(_mapper.Map<Orders,OrdersDTO>(order));
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<int> Post([FromBody] OrdersDTO order)
        {
            Orders o = _mapper.Map<OrdersDTO, Orders>(order);
            o=await _iOrdersBL.Post(o);
            order = _mapper.Map<Orders, OrdersDTO>(o);
            return order.OrderId;
        }
    }
}
