using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Facilities.Queries
{
    public class SampleQuery:IRequest<Result<List<ClinicDto>>>
    {
        public string Name { get;  }

        public SampleQuery(string name)
        {
            Name = name;
        }
    }

    public class SampleQueryHandler : IRequestHandler<SampleQuery, Result<List<ClinicDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;

        public SampleQueryHandler(IMapper mapper, IClinicRepository clinicRepository)
        {
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }

        public Task<Result<List<ClinicDto>>> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinics = _clinicRepository
                    .GetAll(x=>x.Name.ToLower().Contains(request.Name.ToLower()))
                    .ToList();
                var results= _mapper.Map<List<ClinicDto>>(clinics);

                return Task.FromResult(Result.Success(results));
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                return Task.FromResult(Result.Failure<List<ClinicDto>>(e.Message));
            }
        }
    }
}
