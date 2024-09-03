using Hospital.Logic.Models;
using Hospital.Logic.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interfaces
{
    public interface IDoctorService
    {
        Task Add(Doctor doctor);

        Task Update(long doctorId, DoctorUpdate doctor);

        Task Delete(long doctorId);

        Task<Doctor> GetById(long id);

        Task<IReadOnlyList<Doctor>> GetSortedByPage(string sortedField = "id", int page = 0);
    }
}
