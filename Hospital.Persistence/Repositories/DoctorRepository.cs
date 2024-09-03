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

        public async Task Create(DoctorCreate doctor)
        {
            var newDoctor = new Doctor
            {
                FullName = doctor.FullName
            };

            await CheckAndFillReferencePreperties(
                newDoctor, 
                doctor.SiteId,
                doctor.SpecializationId,
                doctor.OfficeId
                );

            await _context.Doctors.AddAsync(newDoctor);

            await _context.SaveChangesAsync();
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
                "office" => _context.Doctors.OrderBy(d => d.OfficeId),
                "site" => _context.Doctors.OrderBy(d => d.HospitalSiteId == null ? long.MaxValue : d.HospitalSiteId),
                "specialization" => _context.Doctors.OrderBy(d => d.SpecializationId),
                _ => throw new ArgumentException()
            };


            return await doctorsQuery
                .Skip(pageSize * page)
                .Take(pageSize)
                .Include(d => d.Office)
                .Include(d => d.Site)
                .Include(d => d.Specialization)
                .ToListAsync();
        }

        public async Task Update(long doctorId, DoctorUpdate doctor)
        {
            var existedDoctor = await GetById(doctorId);

            if (existedDoctor is null)
                throw new KeyNotFoundException();

            if (doctor.FullName is not null)
                existedDoctor.FullName = doctor.FullName;

            await CheckAndFillReferencePreperties(
                existedDoctor, 
                doctor.SiteId, 
                doctor.SpecializationId,
                doctor.OfficeId
                );

            await _context.SaveChangesAsync();
        }

        private async Task CheckAndFillReferencePreperties(
            Doctor existedDoctor,
            long? siteId, 
            long? specializationId,
            long? officeId
            )
        {
            if (siteId is not null)
            {
                var site = await _context.HospitalSites
                    .FirstOrDefaultAsync(s => s.Id == siteId);

                if (site is null)
                    throw new KeyNotFoundException();
                existedDoctor.Site = site;
            }

            if (specializationId is not null)
            {
                var specialization = await _context.Specializations
                    .FirstOrDefaultAsync(s => s.Id == specializationId);

                if (specialization is null)
                    throw new KeyNotFoundException();
                existedDoctor.Specialization = specialization;
            }

            if (officeId is not null)
            {
                var office = await _context.Offices
                    .FirstOrDefaultAsync(s => s.Id == officeId);

                if (office is null)
                    throw new KeyNotFoundException();
                existedDoctor.Office = office;
            }
        }
    }
}
