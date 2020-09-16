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
    public class ConsultationFindingService : IConsultationFindingService
    {
        public readonly IMapper _IMapper;
        public readonly IConsultationFindingRepository _ConsultationFindingRepository;

        public ConsultationFindingService(IMapper iMapper, IConsultationFindingRepository consultationRepository)
        {
            _IMapper = iMapper;
            _ConsultationFindingRepository= consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationFinding>, string ErrorMessage)> LoadConsultationFindings()
        {
            IEnumerable<ConsultationFinding> c = new List<ConsultationFinding>();
            try
            {
                var consultations = await _ConsultationFindingRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, _IMapper.Map<List<ConsultationFinding>>(consultations), "Consultation findings loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, ConsultationFinding consultation, string ErrorMEssage)> AddConsultationFinding(ConsultationFinding consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation found");
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationFindingRepository.Create(consultation);
                _ConsultationFindingRepository.Update(consultation);
                await _ConsultationFindingRepository.Save();

                return (true, consultation, "Consultation finding created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationFinding(Guid id)
        {
            try
            {

                var consultation = await _ConsultationFindingRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationFindingRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationFinding> consultations, string ErrorMessage)> GetConsultationFinding(Guid id)
        {
            IEnumerable<ConsultationFinding> lab = new List<ConsultationFinding>();
            try
            {
                var consultation = await _ConsultationFindingRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation finding not found.");
                return (true, _IMapper.Map<List<ConsultationFinding>>(consultation), "Consultation finding loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
