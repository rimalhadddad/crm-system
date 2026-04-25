using CRM.API.DTOs;
using CRM.API.Helpers;
using CRM.API.Interfaces;
using CRM.Data.Context;
using CRM.Data.Entities;
using System.Security.Claims;

namespace CRM.API.Services
{

    public class PropertyService : IPropertyService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public PropertyService(AppDbContext context, IHttpContextAccessor httpContext)
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

        public ApiResponse<List<Property>> GetMyProperties()
        {
            var userId = GetUserId();

            var properties = _context.Properties
         .Where(p => p.UserId == userId)
         .ToList();

            return new ApiResponse<List<Property>>
            {
                Success = true,
                Message = "Properties retrieved successfully",
                Data = properties
            };
        }

      

        public ApiResponse<Property> Create(PropertyDto dto)
        {
            var userId = GetUserId();

            var property = new Property
            {
               
                Title = dto.Title,
                Address = dto.Address,
                Price = dto.Price,
                UserId = userId
            };

            _context.Properties.Add(property);
            _context.SaveChanges();

            return new ApiResponse<Property>
            {
                Success = true,
                Message = "Property created successfully",
                Data = property
            };
        }

        public ApiResponse<Property> Update(int id, PropertyDto dto)
        {
            var userId = GetUserId();

            var property = _context.Properties
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (property == null)
            {
                return new ApiResponse<Property>
                {
                    Success = false,
                    Message = "Property not found"
                };
            }

            property.Title = dto.Title;
            property.Address = dto.Address;
            property.Price = dto.Price;

            _context.SaveChanges();

            return new ApiResponse<Property>
            {
                Success = true,
                Message = "Property updated successfully",
                Data = property
            };
        }

        public ApiResponse<object> Delete(int id)
        {
            var userId = GetUserId();

            var property = _context.Properties
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (property == null)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "Property not found"
                };
            }

            _context.Properties.Remove(property);
            _context.SaveChanges();

            return new ApiResponse<object>
            {
                Success = true,
                Message = "Property deleted successfully"
            };
        }
    }
}