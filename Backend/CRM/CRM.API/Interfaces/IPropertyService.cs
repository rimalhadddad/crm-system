using Azure;
using CRM.API.DTOs;
using CRM.API.Helpers;
using CRM.Data.Entities;
namespace CRM.API.Interfaces

{
    public interface IPropertyService
    {
        ApiResponse<List<Property>> GetMyProperties();
        ApiResponse<Property> Create(PropertyDto dto);
        ApiResponse<Property> Update(int id, PropertyDto dto);
        ApiResponse<object> Delete(int id);
    }
}
