using EasyShop.Application.Interfaces.Repositories;
using EasyShop.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository Products { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(AppDbContext context,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            Products = productRepository;
            Orders = orderRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
