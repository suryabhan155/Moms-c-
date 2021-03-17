using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface ILabOrderSampleStatusService
    {

        Task<(bool IsSuccess, IEnumerable<LabOrderSampleStatus>, string ErrorMessage)> LoadLabOrderSampleStatus();
        Task<(bool IsSuccess, IEnumerable<LabOrderSampleStatus> labOrderSampleStatuses, string ErrorMessage)> GetLabOrderSampleStatus(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSampleStatus(Guid id);
        Task<(bool IsSuccess, LabOrderSampleStatus labOrderSampleStatus, string ErrorMEssage)> AddLabOrderSampleStatus(LabOrderSampleStatus labOrderSampleStatus);


    }
}
