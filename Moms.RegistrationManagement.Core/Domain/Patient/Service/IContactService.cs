using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Service
{
    public interface IContactService
    {
        Task<(bool IsSuccess, IEnumerable<ContactDto>, string ErrorMessage)> LoadContacts();
        Task<(bool IsSuccess, Contact contact , string ErrorMessage)> GetContacts(Guid id);
        Task<(bool IsSuccess, IEnumerable<ContactDto>, string ErrorMessage)> GetPatientContacts(Guid patientId);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteContact(Guid id);
        Task<(bool IsSuccess,Contact contact, string ErrorMEssage )> AddContact(Contact contact);
    }
}
