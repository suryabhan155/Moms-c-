using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Moms.Clinical.Core.Application.Consultation.Events;
using Moms.Clinical.Core.Domain.Consultation;
using Serilog;

namespace Moms.Clinical.Core.Application.Consultation.Commands
{
    public class SampleCommand : IRequest<Result>
    {
        public Guid Id { get; }

        public SampleCommand(Guid id)
        {
            Id = id;
        }
    }

    public class SampleCommandHandler : IRequestHandler<SampleCommand, Result>
    {
        private readonly IMediator _mediator;
        private readonly IConsultationRepository _consultationRepository;

        public SampleCommandHandler(IMediator mediator, IConsultationRepository consultationRepository)
        {
            _mediator = mediator;
            _consultationRepository = consultationRepository;
        }


        public Task<Result> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _consultationRepository.DeleteById(request.Id);

                _mediator.Publish(new SampleEvent(request.Id), cancellationToken);

                return Task.FromResult(Result.Success());
            }
            catch (Exception e)
            {
                Log.Error("Error occured", e);
                return Task.FromResult(Result.Failure(e.Message));
            }
        }
    }
}
