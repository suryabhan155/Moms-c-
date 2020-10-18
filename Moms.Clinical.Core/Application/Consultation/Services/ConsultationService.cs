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
    public class ConsultationService : IConsultationService
    {
        public readonly IConsultationRepository _ConsultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _ConsultationRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.Consultation>, string ErrorMessage)> LoadConsultations()
        {
            IEnumerable<Domain.Consultation.Models.Consultation> c = new List<Domain.Consultation.Models.Consultation>();
            try
            {
                var consultations = await _ConsultationRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, consultations, "Consultations loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.Consultation consultation, string ErrorMEssage)> AddConsultation(Domain.Consultation.Models.Consultation consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation found");
                if (consultation.Id.IsNullOrEmpty())
                {
                    _ConsultationRepository.Create(consultation);
                }
                else
                {
                    _ConsultationRepository.Update(consultation);
                }
                await _ConsultationRepository.Save();

                return (true, consultation, "Consultation created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultation(Guid id)
        {
            try
            {

                var consultation = await _ConsultationRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.Consultation> consultations, string ErrorMessage)> GetConsultation(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.Consultation> lab = new List<Domain.Consultation.Models.Consultation>();
            try
            {
                var consultation = await _ConsultationRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation not found.");
                return (true, consultation, "Consultation loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
