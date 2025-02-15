namespace lovedmemory.application.Contracts;

public record CurrentUser(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles);