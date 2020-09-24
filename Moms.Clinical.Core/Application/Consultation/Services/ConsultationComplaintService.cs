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
    public class ConsultationComplaintService : IConsultationComplaintService
    {
        public readonly IConsultationComplaintRepository _ConsultationComplaintRepository;

        public ConsultationComplaintService(IConsultationComplaintRepository consultationRepository)
        {
            _ConsultationComplaintRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationComplaint>, string ErrorMessage)> LoadConsultationComplaints()
        {
            IEnumerable<Domain.Consultation.Models.ConsultationComplaint> c = new List<Domain.Consultation.Models.ConsultationComplaint>();
            try
            {
                var consultations = await _ConsultationComplaintRepository.GetAll().ToListAsync();
                if (consultations == null)
                    return (false, c, "No record found.");
                return (true, consultations, "Consultation complaints loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.ConsultationComplaint consultation, string ErrorMEssage)> AddConsultationComplaint(Domain.Consultation.Models.ConsultationComplaint consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, "No consultation found");
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationComplaintRepository.Create(consultation);
                _ConsultationComplaintRepository.Update(consultation);
                await _ConsultationComplaintRepository.Save();

                return (true, consultation, "Consultation complaint created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationComplaint(Guid id)
        {
            try
            {

                var consultation = await _ConsultationComplaintRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, "No record found.");
                _ConsultationComplaintRepository.Delete(consultation);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationComplaint> consultations, string ErrorMessage)> GetConsultationComplaint(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.ConsultationComplaint> lab = new List<Domain.Consultation.Models.ConsultationComplaint>();
            try
            {
                var consultation = await _ConsultationComplaintRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Consultation complaint not found.");
                return (true, consultation, "Consultation complaint loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
