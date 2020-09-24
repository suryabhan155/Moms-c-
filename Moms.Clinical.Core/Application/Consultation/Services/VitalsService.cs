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
        public readonly IMapper _IMapper;
        public readonly IVitalsRepository _VitalsRepository;

        public VitalsService(IMapper iMapper, IVitalsRepository vitalsRepository)
        {
            _IMapper = iMapper;
            _VitalsRepository = vitalsRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Vital>, string ErrorMessage)> LoadVitals()
        {
            IEnumerable<Vital> c = new List<Vital>();
            try
            {
                var vitalses = await _VitalsRepository.GetAll().ToListAsync();
                if (vitalses == null)
                    return (false, c, "No record found.");
                return (true, _IMapper.Map<List<Vital>>(vitalses), "Vitals loaded successfully.");
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
                if (vitals.PatientId.IsNullOrEmpty())
                    _VitalsRepository.Create(vitals);
                _VitalsRepository.Update(vitals);
                await _VitalsRepository.Save();

                return (true, vitals, "Vitals created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

        public async Task<(bool IsSuccess, IEnumerable<Vital> vitalses, string ErrorMessage)> GetVitals(Guid id)
        {
            IEnumerable<Vital> lab = new List<Vital>();
            try
            {
                var consultation = await _VitalsRepository.GetAll(x => x.Id == id).ToListAsync();
                if (consultation == null)
                    return (false, lab, "Vitals not found.");
                return (true, _IMapper.Map<List<Vital>>(consultation), "Vitals loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

    }
}
