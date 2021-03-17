using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Moms.Clinical.Core.Application.Consultation.Events
{
    public class SampleEvent : INotification
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; } = DateTime.Now;

        public SampleEvent(Guid id)
        {
            Id = id;
        }
    }
}
