using Hospital.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logic.Store
{
    public interface IDoctorStore
    {
        Task Create(Doctor doctor);

        Task Update(Doctor doctor);

        Task Delete(long id);

        Task<Doctor> GetById(long id);

        Task<IReadOnlyList<Doctor>> GetSortedByPage(string sortedField = "id", int page = 0);
    }
}
