using Hospital.Application.Interfaces;
using Hospital.Logic.Models;
using Hospital.Logic.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientStore _patientStore;

        public PatientService(IPatientStore patientStore)
        {
            _patientStore = patientStore;
        }
        public async Task Add(PatientCreate patient)
        {
            await _patientStore.Create(patient);
        }

        public async Task Delete(long patientId)
        {
            await _patientStore.Delete(patientId);
        }

        public async Task<Patient> GetById(long id)
        {
            return await _patientStore.GetById(id);
        }

        public async Task<IReadOnlyList<Patient>> GetSortedByPage(string sortedField = "id", int page = 0)
        {
            var patientFields = new string[] { 
                "id", 
                "name", 
                "surname",
                "patronymic",
                "address",
                "birthdate",
                "sex",
                "site"
            };

            if (!patientFields.Contains(sortedField.ToLower()) || page < 0)
            {
                throw new ArgumentException();
            }

            return await _patientStore.GetSortedByPage(sortedField, page);
        }

        public async Task Update(long patietnId, PatientUpdate patient)
        {
            await _patientStore.Update(patietnId, patient);
        }

    }
}
