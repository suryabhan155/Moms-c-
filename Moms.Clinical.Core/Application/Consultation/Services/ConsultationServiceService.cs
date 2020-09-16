using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationServiceService : IConsultationServiceService
    {
        public readonly IMapper _IMapper;
        public readonly IConsultationServiceRepository _ConsultationServiceRepository;

        public ConsultationServiceService(IMapper iMapper, IConsultationServiceRepository consultationRepository)
        {
            _IMapper = iMapper;
            _ConsultationServiceRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationService>, string ErrorMessage)> LoadConsultationServices()
        {
            IEnumerable<Domain.Consultation.Models.ConsultationService> c = new List<Domain.Consultation.Models.ConsultationService>();
            try
            {
                var consultations = await _ConsultationServiceRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, _IMapper.Map<List<Domain.Consultation.Models.ConsultationService>>(consultations), "Consultation findings loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.ConsultationService consultation, string ErrorMEssage)> AddConsultationService(Domain.Consultation.Models.ConsultationService consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation found");
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationServiceRepository.Create(consultation);
                _ConsultationServiceRepository.Update(consultation);
                await _ConsultationServiceRepository.Save();

                return (true, consultation, "Consultation service created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationService(Guid id)
        {
            try
            {

                var consultation = await _ConsultationServiceRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationServiceRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationService> consultations, string ErrorMessage)> GetConsultationServices(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.ConsultationService> lab = new List<Domain.Consultation.Models.ConsultationService>();
            try
            {
                var consultation = await _ConsultationServiceRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation service not found.");
                return (true, _IMapper.Map<List<Domain.Consultation.Models.ConsultationService>>(consultation), "Consultation service loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
