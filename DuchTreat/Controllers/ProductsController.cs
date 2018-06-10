using DuchTreat.Data;
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
    public class ProductsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<IDutchRepository> _logger;

        public ProductsController(IDutchRepository repository , ILogger<IDutchRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
               
               
                return Ok(_repository.GetAllProducts());
            }
            catch( Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get Products");
            }
        }



    }
}
