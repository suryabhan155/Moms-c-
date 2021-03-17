using System;
using MediatR;

namespace Moms.RegistrationManagement.Core.Application.Facilities.Events
{
    public class SampleEvent:INotification
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; }=DateTime.Now;

        public SampleEvent(Guid id)
        {
            Id = id;
        }
    }
}
