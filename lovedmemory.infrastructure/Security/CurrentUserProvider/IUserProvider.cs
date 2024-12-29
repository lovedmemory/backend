namespace lovedmemory.Infrastructure.Security.CurrentUserProvider
{
    public interface IUserProvider
    {
        CurrentUser GetCurrentUser();
    }
}
