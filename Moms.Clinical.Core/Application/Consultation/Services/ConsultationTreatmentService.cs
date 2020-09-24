using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationTreatmentService : IConsultationTreatmentService
    {
        public readonly IConsultationTreatmentRepository _ConsultationTreatmentRepository;

        public ConsultationTreatmentService(IConsultationTreatmentRepository consultationRepository)
        {
            _ConsultationTreatmentRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationTreatment>, string ErrorMessage)> LoadConsultationTreatments()
        {
            IEnumerable<ConsultationTreatment> c = new List<ConsultationTreatment>();
            try
            {
                var consultations = await _ConsultationTreatmentRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, consultations, "Consultation findings loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, ConsultationTreatment consultation, string ErrorMEssage)> AddConsultationTreatment(ConsultationTreatment consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation found");
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationTreatmentRepository.Create(consultation);
                _ConsultationTreatmentRepository.Update(consultation);
                await _ConsultationTreatmentRepository.Save();

                return (true, consultation, "Consultation finding created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationTreatment(Guid id)
        {
            try
            {

                var consultation = await _ConsultationTreatmentRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationTreatmentRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationTreatment> consultations, string ErrorMessage)> GetConsultationTreatments(Guid id)
        {
            IEnumerable<ConsultationTreatment> lab = new List<ConsultationTreatment>();
            try
            {
                var consultation = await _ConsultationTreatmentRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation finding not found.");
                return (true, consultation, "Consultation finding loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
