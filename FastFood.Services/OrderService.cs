using FastFood.Services.Models.Orders;
using FastFood.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        public Task AddOrder(CreateOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ListOrderDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
