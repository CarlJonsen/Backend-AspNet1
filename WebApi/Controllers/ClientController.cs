using Infrastructure.Business.Domains.Dto;
using Infrastructure.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { Errors = errors });
            }
            try
            {
                var result = await _clientService.CreateClientAsync(request);
                return result ? Ok("Klient skapad") : BadRequest("Misslyckades");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }
    }
}
