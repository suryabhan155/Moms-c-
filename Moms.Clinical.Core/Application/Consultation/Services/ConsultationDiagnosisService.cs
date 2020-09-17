using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationDiagnosisService : IConsultationDiagnosisService
    {
        public readonly IConsultationDiagnosisRepository _ConsultationDiagnosisRepository;

        public ConsultationDiagnosisService(IConsultationDiagnosisRepository consultationRepository)
        {
            _ConsultationDiagnosisRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationDiagnosis>, string ErrorMessage)> LoadConsultationDiagnosis()
        {
            IEnumerable<ConsultationDiagnosis> c = new List<ConsultationDiagnosis>();
            try
            {
                var consultations = await _ConsultationDiagnosisRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, consultations, "Consultation diagnosis loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, ConsultationDiagnosis consultation, string ErrorMEssage)> AddConsultationDiagnosis(ConsultationDiagnosis consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation diagnosis found");
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationDiagnosisRepository.Create(consultation);
                _ConsultationDiagnosisRepository.Update(consultation);
                await _ConsultationDiagnosisRepository.Save();

                return (true, consultation, "Consultation diagnosis created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationDiagnosis(Guid id)
        {
            try
            {

                var consultation = await _ConsultationDiagnosisRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationDiagnosisRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationDiagnosis> consultations, string ErrorMessage)> GetConsultationDiagnosis(Guid id)
        {
            IEnumerable<ConsultationDiagnosis> lab = new List<ConsultationDiagnosis>();
            try
            {
                var consultation = await _ConsultationDiagnosisRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation diagnosis not found.");
                return (true, consultation, "Consultation diagnosis loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
