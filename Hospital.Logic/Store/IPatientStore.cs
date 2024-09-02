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
        Task Create(Patient doctor);

        Task Update(Patient doctor);

        Task Delete(long id);

        Task<Patient> GetById(long id);

        Task<IReadOnlyList<Patient>> GetSortedByPage(string sortedField = "id", int page = 0);
    }
}
