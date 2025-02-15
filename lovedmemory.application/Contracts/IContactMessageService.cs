using lovedmemory.application.Common.Models;
using lovedmemory.application.DTOs;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Contracts
{
    public interface IContactMessageService
    {
        Task<bool> DeleteContactUs(int id, CancellationToken cancellationToken);
        Task<Result<IEnumerable<Contact>>> GetContactMessages();
        Task<Result<Contact>> PostContactUs(ContactUsDto ContactUsDto, CancellationToken cancellationToken);
    }
}