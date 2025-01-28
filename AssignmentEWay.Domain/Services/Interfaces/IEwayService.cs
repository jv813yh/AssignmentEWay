using AssignmentEWay.Data.Models;
using AssignmentEWay.Shared.Dtos;

namespace AssignmentEWay.Domain.Services.Interfaces
{
    public interface IEwayService
    {
        Task<ApiResponse<Contact>> GetContactByEmailAsync(string emailAddress, string? guid = null);
    }
}
