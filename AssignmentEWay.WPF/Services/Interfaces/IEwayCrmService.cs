using AssignmentEWay.Data.Models;
using AssignmentEWay.Shared.Dtos;

namespace AssignmentEWay.WPF.Services.Interfaces
{
    public interface IEwayCrmService
    {
        Task<ApiResponse<Contact>> GetContactByEmailAsync(string emailAddress, string? guid = null);
    }
}
