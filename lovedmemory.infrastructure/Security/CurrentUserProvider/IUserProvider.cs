namespace lovedmemory.infrastructure.Security.CurrentUserProvider
{
    public interface IUserProvider
    {
        CurrentUser GetCurrentUser();
    }
}
