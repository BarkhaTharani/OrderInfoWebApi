using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderInformationWebApi.Models;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Services;

namespace OrderInformationWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersService _ordersService;

        public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService)
        {
            _logger = logger;
            _ordersService = ordersService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> Get()
        {
            var order = _ordersService.GetAllOrders();
            if (order != null)
                return Ok(order);
            return NoContent();

        }

        [HttpGet("{orderNumber}")]
        public ActionResult<List<OrderDto>> Get([FromRoute] string orderNumber)
        {
            var order = _ordersService.GetOrder(orderNumber);
            if (order != null)
                return Ok(order);
            return NoContent();

        }

        [HttpPost]
        public ActionResult Post()
        {
            var res =_ordersService.PostOrder();
            if (res)
                return Ok();
            else
                return BadRequest();
        }
    }
}
