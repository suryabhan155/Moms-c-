using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Patient.Services
{
    public class ContactService: IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<ContactDto>, string ErrorMessage)> LoadContacts()
        {
            try
            {
                var contacts = await _contactRepository.GetAll().ToListAsync();
                return (true,_mapper.Map<List<ContactDto>>(contacts),"Patient Contacts Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("patient Contact Load: Error occured",e);
                IEnumerable<ContactDto>  contactDto=new List<ContactDto>();
                return (false, contactDto, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Contact contact, string ErrorMessage)> GetContacts(Guid id)
        {
            try
            {
                var contacts = await _contactRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                return (true, contacts, "Patient contacts Loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("patient Contact Load: Error occured",e);
                Contact  contact=new Contact();
                return (false, contact, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ContactDto>, string ErrorMessage)> GetPatientContacts(Guid patientId)
        {
            try
            {
                var contact = await _contactRepository.GetAll(x => x.PatientId == patientId).ToListAsync();
                return (true,_mapper.Map<List<ContactDto>>(contact),"Patient Contact(s) Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error in loading patient Contacts");
                IEnumerable<ContactDto> contactDtos = new List<ContactDto>();
                return (false, contactDtos, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteContact(Guid id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    return (false, id, "Empty contact Id provided");
                var contact = await _contactRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (contact == null)
                    return (false, id, "Contact NOT found");
                _contactRepository.Delete(contact);
                return (true, id, "Contact deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error($"Error deleting Contact with Id: {id}");
                return (false, id, $"{e.Message}");
            }

        }

        public async Task<(bool IsSuccess, Contact contact, string ErrorMEssage)> AddContact(Contact contact)
        {
            try
            {
                if (contact == null)
                    return (false, new Contact(), "Empty model provided");
                if(contact.Id.IsNullOrEmpty())
                    _contactRepository.Create(contact);
                _contactRepository.Update(contact);
                await _contactRepository.Save();
                return (true, contact, "Contact added successfully");
            }
            catch (Exception e)
            {
                Log.Error("New Contacts added successfully");
                Contact contacts= new Contact();
                return (false, contacts, e.Message);
            }
        }
    }
}
