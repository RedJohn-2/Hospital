using Hospital.Logic.Models;
using Hospital.Logic.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Persistence.Repositories
{
    public class DoctorRepository : IDoctorStore
    {

        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task Delete(long id)
        {
            await _context.Doctors.Where(d => d.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Doctor> GetById(long id)
        {
            var existedDoctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);

            if (existedDoctor == null)
            {
                throw new KeyNotFoundException();
            }

            return existedDoctor;
        }

        public async Task<IReadOnlyList<Doctor>> GetSortedByPage(string sortedField = "id", int page = 0)
        {
            var pageSize = 10;

            var doctorsQuery = sortedField switch
            {
                "id" => _context.Doctors.OrderBy(d => d.Id),
                "fullname" => _context.Doctors.OrderBy(d => d.FullName),
                "office" => _context.Doctors.OrderBy(d => d.Office.Id),
                "site" => _context.Doctors.OrderBy(d => d.Site == null ? long.MaxValue : d.Site.Id),
                "specialization" => _context.Doctors.OrderBy(d => d.Specialization.Id),
                _ => throw new ArgumentException()
            };


            return await doctorsQuery.Skip(pageSize * page).Take(pageSize).ToListAsync();
        }

        public async Task Update(long doctorId, DoctorUpdate doctor)
        {
            var existedDoctor = await GetById(doctorId);

            if (existedDoctor is null)
                throw new KeyNotFoundException();

            if (doctor.FullName is not null)
                existedDoctor.FullName = doctor.FullName;

            if (doctor.SiteId is not null)
            {
                var site = await _context.HospitalSites
                    .FirstOrDefaultAsync(s => s.Id == doctor.SiteId);

                if (site is null)
                    throw new KeyNotFoundException();
                existedDoctor.Site = site;
            }

            if (doctor.SpecializationId is not null)
            {
                var specialization = await _context.Specializations
                    .FirstOrDefaultAsync(s => s.Id == doctor.SpecializationId);

                if (specialization is null)
                    throw new KeyNotFoundException();
                existedDoctor.Specialization = specialization;
            }

            if (doctor.OfficeId is not null)
            {
                var office = await _context.Offices
                    .FirstOrDefaultAsync(s => s.Id == doctor.OfficeId);

                if (office is null)
                    throw new KeyNotFoundException();
                existedDoctor.Office = office;
            }

            await _context.SaveChangesAsync();
        }
    }
}
