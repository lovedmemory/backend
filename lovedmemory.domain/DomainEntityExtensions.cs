using lovedmemory.domain.Entities;

namespace lovedmemory.domain
{
    public static class DomainEntityExtensions
    {
        public static string FullName(this Tribute value)
            => $"{value.FirstName} {value.LastName}";
    }
}
