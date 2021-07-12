using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ICrudRepository<Client> _repo;

        public ClientController(ICrudRepository<Client> repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<IList<Client>>> GetAllClient()
        {
            var listClient = await _repo.GetAll();
            return (listClient.Count > 0) ? Ok(listClient) : NotFound("Client not found");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            if (id <= 0)
                return BadRequest("Id is not valid.");

            var client = await _repo.GetByIdAsync(id);
            return (client != null) ? Ok(client) : NotFound("Client not found");
        }

        [HttpPost]
        public async Task<ActionResult<Client>> ClientPost(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error to create the client.");

            var resp = await _repo.Save(client);
            return (resp) ? Ok($"Client {client.FirstName} was created successfully") : BadRequest("Error to create the client.");
        }

        [HttpPut]
        public ActionResult<Client> ClientUpdate(Client client)
        {
            if (client == null)
                return BadRequest("Error to update the client.");

            var resp = _repo.Update(client);
            return (resp) ? Ok($"Client {client.FirstName} was updated with successfully") : BadRequest("Error to update the client.");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Client> ClientDelete(int id)
        {
            if (id <= 0)
                return BadRequest("Id is not valid.");

            var resp = _repo.Delete(id);
            return (resp) ? Ok("Client was deleted successfully") : NotFound("Client not found");
        }
    }
}