using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Moms.RegistrationManagement.Core.Application.Facilities.Events;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Facilities.Commands
{
    public class SampleCommand : IRequest<Result>
    {
        public Guid Id { get; }

        public SampleCommand(Guid id)
        {
            Id = id;
        }
    }

    public class SampleCommandHandler:IRequestHandler<SampleCommand,Result>
    {
        private readonly IMediator _mediator;
        private readonly IClinicRepository _clinicRepository;

        public SampleCommandHandler(IMediator mediator, IClinicRepository clinicRepository)
        {
            _mediator = mediator;
            _clinicRepository = clinicRepository;
        }

        public Task<Result> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _clinicRepository.DeleteById(request.Id);

                _mediator.Publish(new SampleEvent(request.Id),cancellationToken);

                return Task.FromResult(Result.Success());
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                return Task.FromResult(Result.Failure(e.Message));
            }
        }
    }
}
