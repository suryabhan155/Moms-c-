﻿using System;
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
    public class ConsultationService : IConsultationService
    {
        public readonly IConsultationRepository _ConsultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _ConsultationRepository = consultationRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.Consultation>, ResponseModel model)> LoadConsultations()
        {
            IEnumerable<Domain.Consultation.Models.Consultation> c = new List<Domain.Consultation.Models.Consultation>();
            try
            {
                var consultations = await _ConsultationRepository.GetAll(x => !x.Void).ToListAsync();
                if (consultations == null)
                    return (false, c, new ResponseModel { message = "No record found.", data = c, code = HttpStatusCode.NotFound });
                return (true, consultations, new ResponseModel { message = "Consultations loaded successfully.", data = consultations, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Domain.Consultation.Models.Consultation consultation, ResponseModel model)> AddConsultation(Domain.Consultation.Models.Consultation consultation)
        {
            try
            {
                if (consultation == null)
                    return (false, consultation, new ResponseModel { message = "No consultation found", data = consultation, code = HttpStatusCode.NotFound });
                if (consultation.Id.IsNullOrEmpty())
                {
                    _ConsultationRepository.Create(consultation);
                }
                else
                {
                    _ConsultationRepository.Update(consultation);
                }
                await _ConsultationRepository.Save();

                return (true, consultation, new ResponseModel { message = "Consultation created successfully", data = consultation, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultation(Guid id)
        {
            try
            {

                var consultation = await _ConsultationRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (consultation == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _ConsultationRepository.Delete(consultation);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Consultation.Models.Consultation> consultations, ResponseModel model)> GetConsultation(Guid id)
        {
            IEnumerable<Domain.Consultation.Models.Consultation> lab = new List<Domain.Consultation.Models.Consultation>();
            try
            {
                var consultation = await _ConsultationRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, new ResponseModel { message = "Consultation not found.", data = lab, code = HttpStatusCode.NotFound });
                return (true, consultation, new ResponseModel { message = "Consultation loaded successfully", data = consultation, code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = e.Message, data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
