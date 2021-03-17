using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;
using Moms.Clinical.Core.Application.Consultation.Response;
using System.Net;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationComplaintService : IConsultationComplaintService
    {
        public readonly IConsultationComplaintRepository _ConsultationComplaintRepository;

        public ConsultationComplaintService(IConsultationComplaintRepository consultationRepository)
        {
            _ConsultationComplaintRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.ConsultationComplaint>, ResponseModel model)> LoadConsultationComplaints()
        {
            IEnumerable<Domain.Consultation.Models.ConsultationComplaint> c = new List<Domain.Consultation.Models.ConsultationComplaint>();
            try
            {
                var consultations = await _ConsultationComplaintRepository.GetAll(x=>!x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c, new ResponseModel {message = "No record found.",data = c,code = HttpStatusCode.NotFound});
                return (true, consultations, new ResponseModel { message = "Consultation complaints loaded successfully.", data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.ConsultationComplaint consultation, ResponseModel model)> AddConsultationComplaint(Domain.Consultation.Models.ConsultationComplaint consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message = "No consultation found", data = consultation, code = HttpStatusCode.NotFound });
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationComplaintRepository.Create(consultation);
                _ConsultationComplaintRepository.Update(consultation);
                await _ConsultationComplaintRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation complaint created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationComplaint(Guid id)
        {
            try
            {

                var consultation = await _ConsultationComplaintRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = consultation, code = HttpStatusCode.NotFound });
                _ConsultationComplaintRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationComplaint> consultations, ResponseModel model)> GetConsultationComplaint(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.ConsultationComplaint> lab = new List<Domain.Consultation.Models.ConsultationComplaint>();
            try
            {
                var consultation = await _ConsultationComplaintRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, new ResponseModel { message = "Consultation complaint not found.", data = lab, code = HttpStatusCode.NotFound });
                return (true, consultation, new ResponseModel { message = "Consultation complaint loaded successfully", data = lab, code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = e.Message, data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
