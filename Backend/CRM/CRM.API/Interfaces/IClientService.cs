using CRM.Data.Entities;
using CRM.API.DTOs;
using CRM.API.Helpers;

namespace CRM.API.Interfaces
{
    public interface IClientService
    {
        ApiResponse<List<ClientDto>> GetMyClients();
        ApiResponse <ClientDto> Create(ClientCreateDto dto);
        ApiResponse<ClientDto> Update(Guid id, ClientCreateDto dto);
        ApiResponse<object> Delete(Guid id);
        ApiResponse<object> AssignProperty(AssignPropertyDto dto);
    }
}
