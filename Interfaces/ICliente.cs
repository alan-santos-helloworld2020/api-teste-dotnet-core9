public interface ICliente
{
    public Task<List<Cliente>> GetClientes();
    public Task<Cliente?> GetClienteById(int id);
    public Task<bool> AddCliente(Cliente? cliente);
    public Task<bool> UpdateCliente(Cliente cliente);
    public Task<bool> DeleteCliente(int id);
    
}