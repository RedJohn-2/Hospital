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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorStore _doctorStore;

        public DoctorService(IDoctorStore doctorStore)
        {
            _doctorStore = doctorStore;
        }

        public async Task Add(Doctor doctor)
        {
            await _doctorStore.Create(doctor);
        }

        public async Task Delete(long doctorId)
        {
            await _doctorStore.Delete(doctorId);
        }

        public Task<Doctor> GetById(long id)
        {
            return _doctorStore.GetById(id);
        }

        public async Task<IReadOnlyList<Doctor>> GetSortedByPage(string sortedField = "id", int page = 0)
        {
            var patientFields = new string[] {
                "id",
                "fullname",
                "specialization",
                "office",
                "site"
            };

            if (!patientFields.Contains(sortedField.ToLower()) || page < 0)
            {
                throw new ArgumentException();
            }

            return await _doctorStore.GetSortedByPage(sortedField, page);
        }

        public async Task Update(long doctorId, DoctorUpdate doctor)
        {
            await _doctorStore.Update(doctorId, doctor);
        }
    }
}
