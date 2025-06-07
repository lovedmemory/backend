
namespace lovedmemory.application.Common.Security.Request;

public interface IAuthorizeableRequest<T> 
{
    Guid UserId { get; }
}