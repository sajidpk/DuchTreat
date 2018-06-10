using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _dutchContext;
        public readonly ILogger<DutchRepository> _logger;

        public DutchRepository( DutchContext dutchContext , ILogger<DutchRepository> logger)
        {
            _dutchContext = dutchContext;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {

                _logger.LogInformation("GetAllProducts was called");

                return _dutchContext.Products
                                     .OrderBy(p => p.Title)
                                     .ToList();
            }

            catch ( Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _dutchContext.Products
                                .Where(p=>p.Category==category)                 
                                .OrderBy(p => p.Title)
                                .ToList();
        }

        public bool SaveAll()
        {
            return _dutchContext.SaveChanges()>0;

        }

        public IEnumerable<Order> GetAllOrders()
        {

            _logger.LogInformation("GetAllOrders was called");
            return _dutchContext.Orders
                                 .Include(o=>o.Items)
                                 .ThenInclude(i=>i.Product)
                                .ToList();
        }

        public Order GetOrderById(int id)
        {

            _logger.LogInformation("GetOrderById was called");
            return _dutchContext.Orders
                                 .Where(o=>o.Id==id)  
                                 .Include(o => o.Items)
                                 .ThenInclude(i => i.Product)
                                 .FirstOrDefault();
        }

        public void AddEnity(object model)
        {
            _dutchContext.Add(model);
        }
    }
}
