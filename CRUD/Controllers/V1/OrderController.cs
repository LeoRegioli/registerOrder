using System.Threading.Tasks;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ICrudRepository<Order> _repo;
        public OrderController(ICrudRepository<Order> repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<Order>> GetAllOrder()
        {
            // var orderList = await _repo.GetAll();
            // return (orderList.Count > 0) ? Ok(orderList) : NotFound("Product not found.");
            var orderItens = new System.Collections.Generic.List<OrderItens>();
            var itens = new OrderItens();
            itens.Product = new Product();
            orderItens.Add(itens);

            var order = new Order
            {
                Client = new Client(),
                OrderItens = orderItens
            };
            return order;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            if (id <= 0)
                return BadRequest("Id is not valid");

            var orderList = await _repo.GetByIdAsync(id);
            return (orderList != null) ? Ok(orderList) : NotFound("Product not found.");
        }

        [HttpPost]
        public async Task<ActionResult<Order>> OrderPost(Order order)
        {
            if (order == null)
                return BadRequest("Error to create the order.");

            var resp = await _repo.Save(order);
            return (resp) ? Ok($"Order {order.ID} created successfully.") : BadRequest("Error to create the order.");
        }

        [HttpPut]
        public ActionResult<Order> OrderUpdate(Order order)
        {
            if (order == null)
                return BadRequest("Error to update the order.");

            var resp = _repo.Update(order);
            return (resp) ? Ok($"Order {order.ID} was updated with successfully.") : BadRequest("Error to update the order.");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Order> OrderDelete(int id)
        {
            if (id <= 0)
                return BadRequest("Error to delete the order.");

            var resp = _repo.Delete(id);
            return (resp) ? Ok("Order was deleted successfully.") : NotFound("Order not found.");
        }
    }
}