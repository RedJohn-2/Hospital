using Hospital.Logic.Models;
using Hospital.Logic.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interfaces
{
    public interface IPatientService
    {
        Task Add(PatientCreate patient);

        Task Update(long patientId, PatientUpdate patient);

        Task Delete(long patientId);

        Task<Patient> GetById(long id);

        Task<IReadOnlyList<Patient>> GetSortedByPage(string sortedField = "id", int page = 0);
    }
}
