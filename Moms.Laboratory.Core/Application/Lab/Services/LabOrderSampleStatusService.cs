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
    public class LabOrderSampleStatusService: ILabOrderSampleStatusService
    {
        public readonly IMapper _IMapper;
        public readonly ILabOrderSampleStatusRepository _LabOrderSampleStatusRepository;

        public LabOrderSampleStatusService(IMapper iMapper, ILabOrderSampleStatusRepository labOrderSampleStatusRepository)
        {
            _IMapper = iMapper;
            _LabOrderSampleStatusRepository = labOrderSampleStatusRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSampleStatus>, string ErrorMessage)> LoadLabOrderSampleStatus()
        {
            IEnumerable<LabOrderSampleStatus> lab = new List<LabOrderSampleStatus>();
            try
            {
                var labOrderSampleStatus = await _LabOrderSampleStatusRepository.GetAll().ToListAsync();
                if (labOrderSampleStatus == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSampleStatus>>(labOrderSampleStatus), "Lab order samples loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSampleStatus> labOrderSampleStatuses, string ErrorMessage)> GetLabOrderSampleStatus(Guid id)
        {
            IEnumerable<LabOrderSampleStatus> lab = new List<LabOrderSampleStatus>();
            try
            {
                var labOrderSample = await _LabOrderSampleStatusRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSample == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSampleStatus>>(labOrderSample), "Lab order sample loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }
        
        public async Task<(bool IsSuccess, LabOrderSampleStatus labOrderSampleStatus, string ErrorMEssage)> AddLabOrderSampleStatus(LabOrderSampleStatus labOrderSampleStatus)
        {
            try
            {
                if (labOrderSampleStatus == null)
                    return (false, labOrderSampleStatus, "No record found");
                if(labOrderSampleStatus.LabOrderSampleId.IsNullOrEmpty())
                    _LabOrderSampleStatusRepository.Create(labOrderSampleStatus);
                _LabOrderSampleStatusRepository.Update(labOrderSampleStatus);
                await _LabOrderSampleStatusRepository.Save();

                return (true, labOrderSampleStatus, "Lab order sample created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSampleStatus(Guid id)
        {
            try
            {
                var labOrderSample = await _LabOrderSampleStatusRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSample == null)
                    return (false, id, "Record not found");
                _LabOrderSampleStatusRepository.Delete(labOrderSample);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }
    }
}
