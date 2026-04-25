using CRM.API.DTOs;
using CRM.API.Helpers;
using CRM.API.Interfaces;
using CRM.Data.Context;
using CRM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.API.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public ClientService(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        private Guid GetUserId()
        {
            var userId = _httpContext.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Guid.Parse(userId);
        }

        public ApiResponse<List<ClientDto>> GetMyClients()
        {
            var userId = GetUserId();

            var clients = _context.Clients
        .Include(c => c.Property)
        .Where(c => c.UserId == userId)
        .Select(c => new ClientDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Phone = c.Phone,
            PropertyId = c.PropertyId,
            PropertyTitle = c.Property != null ? c.Property.Title : "Unassigned"
        })
        .ToList();

            return new ApiResponse<List<ClientDto>>
            {
                Success = true,
                Message = "Clients retrieved successfully",
                Data = clients
            };
        }

       

       

        public ApiResponse<ClientDto> Create(ClientCreateDto dto)
        {
            var userId = GetUserId();

          
            var client = new Client
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                UserId=userId
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            var result = new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                UserId = client.UserId
            };

            return new ApiResponse<ClientDto>
            {
                Success = true,
                Message = "Client created successfully",
                Data = result
            };
        }

        public ApiResponse<ClientDto> Update(Guid clientId, ClientCreateDto dto)
        {
            var userId = GetUserId();

            var client = _context.Clients
                .FirstOrDefault(x => x.Id == clientId && x.UserId == userId);
            if (client == null)
            {
                return new ApiResponse<ClientDto>
                {
                    Success = false,
                    Message = "Client not found"
                };
            }

            client.Name = dto.Name;
            client.Email = dto.Email;
            client.Phone = dto.Phone;

            _context.SaveChanges();

            return new ApiResponse<ClientDto>
            {
                Success = true,
                Message = "Client updated successfully",
                Data = new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phone = client.Phone,
                    PropertyId = client.PropertyId
                }
            };
        }

        public ApiResponse<object> Delete(Guid clientId)
        {
            var userId = GetUserId();

            var client = _context.Clients
        .FirstOrDefault(x => x.Id == clientId && x.UserId == userId);

            if (client == null)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "Client not found"
                };
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return new ApiResponse<object>
            {
                Success = true,
                Message = "Client deleted successfully"
            };
        }

        public ApiResponse<object> AssignProperty(AssignPropertyDto dto)
        {
            var userId = GetUserId();

            var client = _context.Clients
                .FirstOrDefault(c => c.Id == dto.ClientId && c.UserId == userId);
            if (client == null)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "Client not found"
                };
            }

        
            if (dto.PropertyId == null)
            {
                client.PropertyId = null;
                _context.SaveChanges();

                return new ApiResponse<object>
                {
                    Success = true,
                    Message = "Property unassigned"
                };
            }

            var property = _context.Properties
                .FirstOrDefault(p => p.Id == dto.PropertyId && p.UserId == userId);

            if (property == null)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "Property not found"
                };
            }

            client.PropertyId = dto.PropertyId;
            _context.SaveChanges();

            return new ApiResponse<object>
            {
                Success = true,
                Message = "Property assigned successfully"
            };
        }
    }
}
