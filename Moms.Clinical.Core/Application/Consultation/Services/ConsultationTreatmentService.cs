using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.SharedKernel.Custom;
using Moms.Clinical.Core.Application.Consultation.Response;
using System.Net;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationTreatmentService : IConsultationTreatmentService
    {
        public readonly IConsultationTreatmentRepository _ConsultationTreatmentRepository;

        public ConsultationTreatmentService(IConsultationTreatmentRepository consultationRepository)
        {
            _ConsultationTreatmentRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationTreatment>, ResponseModel model)> LoadConsultationTreatments()
        {
            IEnumerable<ConsultationTreatment> c = new List<ConsultationTreatment>();
            try
            {
                var consultations = await _ConsultationTreatmentRepository.GetAll(x => !x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c, new ResponseModel { message = "No record found.", data =c , code = HttpStatusCode.NotFound });
                return (true, consultations, new ResponseModel { message = "Consultation findings loaded successfully.", data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, ConsultationTreatment consultation, ResponseModel model)> AddConsultationTreatment(ConsultationTreatment consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message = "No consultation found", data = consultation, code = HttpStatusCode.NotFound });
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationTreatmentRepository.Create(consultation);
                _ConsultationTreatmentRepository.Update(consultation);
                await _ConsultationTreatmentRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation finding created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationTreatment(Guid id)
        {
            try
            {

                var consultation = await _ConsultationTreatmentRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _ConsultationTreatmentRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationTreatment> consultations, ResponseModel model)> GetConsultationTreatments(Guid id)
        {
            IEnumerable<ConsultationTreatment> lab = new List<ConsultationTreatment>();
            try
            {
                var consultation = await _ConsultationTreatmentRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, new ResponseModel { message = "Consultation finding not found.", data = lab, code = HttpStatusCode.NotFound });
                return (true, consultation, new ResponseModel { message = "Consultation finding loaded successfully", data = consultation, code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = e.Message, data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
