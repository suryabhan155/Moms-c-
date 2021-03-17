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
    public class ConsultationDiagnosisService : IConsultationDiagnosisService
    {
        public readonly IConsultationDiagnosisRepository _ConsultationDiagnosisRepository;

        public ConsultationDiagnosisService(IConsultationDiagnosisRepository consultationRepository)
        {
            _ConsultationDiagnosisRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationDiagnosis>, ResponseModel model)> LoadConsultationDiagnosis()
        {
            IEnumerable<ConsultationDiagnosis> c = new List<ConsultationDiagnosis>();
            try
            {
                var consultations = await _ConsultationDiagnosisRepository.GetAll(x => !x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c, new ResponseModel {message = "No record found.",data = c ,code = HttpStatusCode.NotFound} );
                return (true, consultations, new ResponseModel { message = "Consultation diagnosis loaded successfully.", data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (true, c, new ResponseModel { message = e.Message, data = c, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, ConsultationDiagnosis consultation, ResponseModel model)> AddConsultationDiagnosis(ConsultationDiagnosis consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message = "No consultation diagnosis found", data = consultation, code = HttpStatusCode.NotFound });
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationDiagnosisRepository.Create(consultation);
                _ConsultationDiagnosisRepository.Update(consultation);
                await _ConsultationDiagnosisRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation diagnosis created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (true, consultation, new ResponseModel { message = e.Message, data = consultation, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationDiagnosis(Guid id)
        {
            try
            {

                var consultation = await _ConsultationDiagnosisRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _ConsultationDiagnosisRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationDiagnosis> consultations, ResponseModel model)> GetConsultationDiagnosis(Guid id)
        {
            IEnumerable<ConsultationDiagnosis> lab = new List<ConsultationDiagnosis>();
            try
            {
                var consultation = await _ConsultationDiagnosisRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, new ResponseModel { message = "Consultation diagnosis not found.", data = lab, code = HttpStatusCode.NotFound });
                return (true, consultation, new ResponseModel { message = "Consultation diagnosis loaded successfully", data = consultation, code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = e.Message, data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
