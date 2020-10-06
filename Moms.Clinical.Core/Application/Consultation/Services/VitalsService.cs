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
    public class VitalsService : IVitalsService
    {
        public readonly IVitalsRepository _VitalsRepository;

        public VitalsService(IVitalsRepository vitalsRepository)
        {
            _VitalsRepository = vitalsRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Vital> vitals, string ErrorMessage)> LoadVitals()
        {
            try
            {
                var vitalses = await _VitalsRepository.GetAll().ToListAsync();
                if (vitalses == null)
                    return (false, new List<Vital>(), "No record found.");
                return (true, vitalses, "Vitals loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Vital vitals, string ErrorMEssage)> AddVitals(Vital vitals)
        {
            try
            {
                if (vitals == null)
                    return (false, vitals, "No vitals found");
                if (vitals.Id.IsNullOrEmpty())
                {
                    _VitalsRepository.Create(vitals);
                }
                else
                {
                    _VitalsRepository.Update(vitals);
                }
                await _VitalsRepository.Save();

                return (true, vitals, "Vitals created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Vital> vitals, string ErrorMEssage)> GetPatientVitals(Guid patientId)
        {
            try
            {
                var vitals = await _VitalsRepository.GetAll(x => x.PatientId == patientId).ToListAsync();
                return (true, vitals, "Vitals loaded successfully.");
            }
            catch (Exception e)
            {
                return (false, new List<Vital>(), $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteVitals(Guid id)
        {
            try
            {

                var vitals = await _VitalsRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (vitals == null)
                    return (false, id, "No record found.");
                _VitalsRepository.Delete(vitals);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, Vital vital, string ErrorMessage) GetVitals(Guid id)
        {
            try
            {
                var consultation = _VitalsRepository.GetById(id);
                if (consultation == null)
                    return (false, null, "Vitals not found.");
                return (true, consultation, "Vitals loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

    }
}
