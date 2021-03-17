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
using Moms.Clinical.Core.Application.Consultation.Response;
using System.Net;

namespace Moms.Clinical.Core.Application.Consultation.Services
{
    public class ConsultationFindingService : IConsultationFindingService
    {
        public readonly IConsultationFindingRepository _ConsultationFindingRepository;

        public ConsultationFindingService(IConsultationFindingRepository consultationRepository)
        {
            _ConsultationFindingRepository= consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ConsultationFinding>, ResponseModel model)> LoadConsultationFindings()
        {
            IEnumerable<ConsultationFinding> c = new List<ConsultationFinding>();
            try
            {
                var consultations = await _ConsultationFindingRepository.GetAll(x => !x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c,new ResponseModel { message = "No record found.",data = c,code = HttpStatusCode.NotFound} );
                return (true, consultations, new ResponseModel { message ="Consultation findings loaded successfully." , data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, ConsultationFinding consultation, ResponseModel model)> AddConsultationFinding(ConsultationFinding consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message ="No consultation found" , data = consultation, code = HttpStatusCode.NotFound } );
                if (consultation.ConsultationId.IsNullOrEmpty())
                    _ConsultationFindingRepository.Create(consultation);
                _ConsultationFindingRepository.Update(consultation);
                await _ConsultationFindingRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation finding created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationFinding(Guid id)
        {
            try
            {

                var consultation = await _ConsultationFindingRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _ConsultationFindingRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ConsultationFinding> consultations, ResponseModel model)> GetConsultationFindings(Guid id)
        {
            IEnumerable<ConsultationFinding> lab = new List<ConsultationFinding>();
            try
            {
                var consultation = await _ConsultationFindingRepository.GetAll(x => x.Id == id).ToListAsync();
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
