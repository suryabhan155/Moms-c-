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
    public class VitalsService : IVitalsService
    {
        public readonly IVitalsRepository _VitalsRepository;

        public VitalsService(IVitalsRepository vitalsRepository)
        {
            _VitalsRepository = vitalsRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Vital> vitals, ResponseModel model)> LoadVitals()
        {
            try
            {
                var vitalses = await _VitalsRepository.GetAll(x => !x.Void).ToListAsync();
                if (vitalses == null)
                    return (false, new List<Vital>(), new ResponseModel { message = "No record found.", data =new List<Vital>(), code = HttpStatusCode.NotFound } );
                return (true, vitalses, new ResponseModel { message = "Vitals loaded successfully.", data = vitalses, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Vital vitals, ResponseModel model)> AddVitals(Vital vitals)
        {
            try
            {
                if (vitals == null)
                    return (false, vitals, new ResponseModel { message = "No vitals found", data = vitals, code = HttpStatusCode.NotFound });
                if (vitals.Id.IsNullOrEmpty())
                {
                    _VitalsRepository.Create(vitals);
                }
                else
                {
                    _VitalsRepository.Update(vitals);
                }
                await _VitalsRepository.Save();

                return (true, vitals, new ResponseModel { message = "Vitals created successfully", data = vitals, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Vital> vitals, ResponseModel model)> GetPatientVitals(Guid patientId)
        {
            try
            {
                var vitals = await _VitalsRepository.GetAll(x => x.PatientId == patientId).ToListAsync();
                return (true, vitals, new ResponseModel { message = "Vitals loaded successfully.", data = vitals, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, new List<Vital>(), new ResponseModel { message = e.Message, data = new List<Vital>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteVitals(Guid id)
        {
            try
            {

                var vitals = await _VitalsRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                if (vitals == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                _VitalsRepository.Delete(vitals);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, Vital vital, ResponseModel model) GetVitals(Guid id)
        {
            try
            {
                var vitals = _VitalsRepository.GetById(id);
                if (vitals == null)
                    return (false, null, new ResponseModel { message = "Vitals not found.", data = null, code = HttpStatusCode.NotFound } );
                return (true, vitals, new ResponseModel { message ="Vitals loaded successfully" , data =vitals , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message =e.Message , data = null, code = HttpStatusCode.InternalServerError });
            }
        }

    }
}
