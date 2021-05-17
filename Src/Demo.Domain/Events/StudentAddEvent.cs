using Core.Ddd.Domain.Events;
using Core.EventBus;

namespace Demo.Domain.Events
{
    [MessageName("customer")]
    public class StudentAddEvent: AggregateRootEvent
    {
    }
}
