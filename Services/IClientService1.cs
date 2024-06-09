using KolokwiumCF.DTOs.Response;

namespace KolokwiumCF.Services
{
    public interface IClientService1
    {
        Task<ClientDTO> GetClientAsync(int id);
    }
}