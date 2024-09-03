using Hospital.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Store
{
    public interface IPatientStore
    {
        Task Create(PatientCreate patient);

        Task Update(long patientId, PatientUpdate patient);

        Task Delete(long id);

        Task<Patient> GetById(long id);

        Task<IReadOnlyList<Patient>> GetSortedByPage(string sortedField = "id", int page = 0);
    }
}
