using AutoMapper;
using DuchTreat.Data;
using DuchTreat.ViewModels;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<IDutchRepository> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IDutchRepository repository, ILogger<IDutchRepository> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_mapper.Map< IEnumerable< Order>, IEnumerable< OrderViewModel>>(_repository.GetAllOrders()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }

        }



        [HttpGet("{id:int}" , Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);

                if (order != null) return Ok( _mapper.Map<Order,OrderViewModel>( order));
                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }

        }


             [HttpPost]
        public IActionResult AddOder( [FromBody]  OrderViewModel model)
        {
            try
            {
                if (model == null || ! ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newOrder = _mapper.Map<OrderViewModel, Order>(model);

                if ( newOrder.OrderDate== DateTime.MinValue)
                {
                    newOrder.OrderDate = DateTime.Now;
                }

                _repository.AddEnity(newOrder);

                if ( _repository.SaveAll())
                {
                    return CreatedAtRoute("GetOrderById", new { id = newOrder.Id }, _mapper.Map< Order, OrderViewModel>(newOrder) );
                }

               

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }

            return BadRequest();

        }

    }
}
