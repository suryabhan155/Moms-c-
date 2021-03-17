using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;
using Moms.Clinical.Core.Application.Consultation.Response;
using System.Net;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationServiceService : IConsultationServiceService
    {
        public readonly IConsultationServiceRepository _ConsultationServiceRepository;

        public ConsultationServiceService(IConsultationServiceRepository consultationRepository)
        {
            _ConsultationServiceRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationService>, ResponseModel model)> LoadConsultationServices()
        {
            IEnumerable<Domain.Consultation.Models.ConsultationService> c = new List<Domain.Consultation.Models.ConsultationService>();
            try
            {
                var consultations = await _ConsultationServiceRepository.GetAll(x => !x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c, new ResponseModel { message = "No record found.", data = c, code = HttpStatusCode.NotFound });
                return (true, consultations, new ResponseModel { message = "Consultation findings loaded successfully.", data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.ConsultationService consultation, ResponseModel model)> AddConsultationService(Domain.Consultation.Models.ConsultationService consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message = "No consultation found", data = consultation, code = HttpStatusCode.NotFound });
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationServiceRepository.Create(consultation);
                _ConsultationServiceRepository.Update(consultation);
                await _ConsultationServiceRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation service created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationService(Guid id)
        {
            try
            {
                var consultation = await _ConsultationServiceRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _ConsultationServiceRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationService> consultations, ResponseModel model)> GetConsultationServices(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.ConsultationService> lab = new List<Domain.Consultation.Models.ConsultationService>();
            try
            {
                var consultation = await _ConsultationServiceRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, new ResponseModel { message = "Consultation service not found.", data = lab, code = HttpStatusCode.NotFound } );
                return (true, consultation, new ResponseModel { message = "Consultation service loaded successfully", data = consultation, code = HttpStatusCode.OK } );

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = e.Message, data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
