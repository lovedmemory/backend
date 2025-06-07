using lovedmemory.application.Common.Interfaces;

namespace lovedmemory.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}
