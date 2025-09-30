namespace teste.Controllers;

using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utils;

[ApiController]
[Route("[controller]")]

public class ClienteController : ControllerBase
{
    private readonly ICliente _clienteService;
    public ClienteController(ICliente clienteService)
    {
        _clienteService = clienteService;
    }
    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _clienteService.GetClientes();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _clienteService.GetClienteById(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> AddCliente([FromBody] ClienteDto cliente)
    {
        var cl = new Cliente
        {
            Id = ClienteBase.clientes.Max(c => c.Id) + 1,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Cep = cliente.Cep,
            DataCadastro = cliente.DataCadastro
        };

        var result = await _clienteService.AddCliente(cl);
        if (!result)
            return BadRequest();
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var result = await _clienteService.DeleteCliente(id);
        if (!result)
            return NotFound();
        return Ok(true);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteDto cliente)
    {
        var cl = new Cliente
        {
            Id = id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Cep = cliente.Cep,
            DataCadastro = cliente.DataCadastro
        };

        var result = await _clienteService.UpdateCliente(cl);
        if (!result)
            return NotFound();
        return Ok(true);
    }           

}