
using System.Text.Json;
using Microsoft.VisualBasic;
using Utils;

class ClienteService : ICliente
{



    public Task<Cliente?> GetClienteById(int id)
    {
        var cliente = ClienteBase.clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return Task.FromResult<Cliente?>(null);
        return Task.FromResult<Cliente?>(cliente);

    }

    public Task<List<Cliente>> GetClientes()
    {
        return Task.FromResult(ClienteBase.clientes);
    }

    public Task<bool> AddCliente(Cliente? cliente)
    {
        if (cliente == null)
            return Task.FromResult(false);
        ClienteBase.clientes.Add(cliente);
        string json = JsonSerializer.Serialize(ClienteBase.clientes, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteCliente(int id)
    {
        var cliente = ClienteBase.clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return Task.FromResult(false);
        ClienteBase.clientes.Remove(cliente);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateCliente(Cliente cliente)
    {
        var existingCliente = ClienteBase.clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (existingCliente == null)
            return Task.FromResult(false);
        existingCliente.Nome = cliente.Nome;
        existingCliente.Email = cliente.Email;
        existingCliente.Telefone = cliente.Telefone;
        existingCliente.Cep = cliente.Cep;
        existingCliente.DataCadastro = cliente.DataCadastro;       
        return Task.FromResult(true);
    }
}