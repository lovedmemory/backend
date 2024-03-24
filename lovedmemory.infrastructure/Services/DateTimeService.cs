using lovedmemory.Application.Common.Interfaces;

namespace lovedmemory.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
