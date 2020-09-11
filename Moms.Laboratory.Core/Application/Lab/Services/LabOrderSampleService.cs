using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Moms.SharedKernel.Custom;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class LabOrderSampleService: ILabOrderSampleService
    {
        public readonly IMapper _IMapper;
        public readonly ILabOrderSampleRepository _LabOrderSampleRepository;

        public LabOrderSampleService(IMapper iMapper, ILabOrderSampleRepository labOrderSampleRepository)
        {
            _IMapper = iMapper;
            _LabOrderSampleRepository = labOrderSampleRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSample>, string ErrorMessage)> LoadLabOrderSamples()
        {
            IEnumerable<LabOrderSample> lab = new List<LabOrderSample>();
            try
            {
                var labOrderSamples = await _LabOrderSampleRepository.GetAll().ToListAsync();
                if (labOrderSamples == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSample>>(labOrderSamples), "Lab order samples loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSample> labOrderSamples, string ErrorMessage)> GetLabOrderSample(Guid id)
        {
            IEnumerable<LabOrderSample> lab = new List<LabOrderSample>();
            try
            {
                var labOrderSample = await _LabOrderSampleRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSample == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSample>>(labOrderSample), "Lab order sample loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, LabOrderSample labOrderSample, string ErrorMEssage)> AddLabOrderSample(LabOrderSample labOrderSample)
        {
            try
            {
                if (labOrderSample == null)
                    return (false, labOrderSample, "No record found");
                if(labOrderSample.LabOrderId.IsNullOrEmpty())
                    _LabOrderSampleRepository.Create(labOrderSample);
                _LabOrderSampleRepository.Update(labOrderSample);
                await _LabOrderSampleRepository.Save();

                return (true, labOrderSample, "Lab order sample created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSample(Guid id)
        {
            try
            {
                var labOrderSample = await _LabOrderSampleRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSample == null)
                    return (false, id, "Record not found");
                _LabOrderSampleRepository.Delete(labOrderSample);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }
    }
}
