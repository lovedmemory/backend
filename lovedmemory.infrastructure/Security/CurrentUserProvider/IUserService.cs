namespace lovedmemory.infrastructure.Security.CurrentUserProvider;

public interface IUserService
{
    CurrentUser GetCurrentUser();
}