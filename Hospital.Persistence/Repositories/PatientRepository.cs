using Hospital.Logic.Models;
using Hospital.Logic.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Persistence.Repositories
{
    public class PatientRepository : IPatientStore
    {
        private readonly ApplicationContext _context;

        public PatientRepository(ApplicationContext context)
        {  
            _context = context; 
        }

        public async Task Create(PatientCreate patient)
        {
            var newPatient = new Patient
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                BirthDate = DateOnly.FromDateTime(patient.BirthDate),
                Sex = patient.Sex
            };

            await CheckAndFillReferencesProperties(newPatient, patient.SiteId);

            await _context.Patients.AddAsync(newPatient);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _context.Patients.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Patient> GetById(long id)
        {
            var existedPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (existedPatient == null) 
            { 
                throw new KeyNotFoundException();
            }

            return existedPatient;
        }

        public async Task<IReadOnlyList<Patient>> GetSortedByPage(string sortedField = "id", int page = 0)
        {
            var pageSize = 10;

            var patientsQuery = sortedField switch
            {
                "id" => _context.Patients.OrderBy(p => p.Id),
                "name" => _context.Patients.OrderBy(p => p.Name),
                "surname" => _context.Patients.OrderBy(p => p.Surname),
                "patronymic" => _context.Patients.OrderBy(p => p.Patronymic),
                "address" => _context.Patients.OrderBy(p => p.Address),
                "birthdate" => _context.Patients.OrderBy(p => p.BirthDate),
                "sex" => _context.Patients.OrderBy(p => p.Sex),
                "site" => _context.Patients.OrderBy(p => p.HospitalSiteId),
                _ => throw new ArgumentException()
            };


            return await patientsQuery
                .Skip(pageSize * page)
                .Take(pageSize)
                .Include(p => p.Site)
                .ToListAsync();
        }

        

        public async Task Update(long patientId, PatientUpdate patient)
        {
            var existedPatient = await GetById(patientId);

            if (existedPatient is null)
                throw new KeyNotFoundException();

            if (patient.Surname is not null)
                existedPatient.Surname = patient.Surname;

            if (patient.Name is not null)
                existedPatient.Name = patient.Name;

            if (patient.Patronymic is not null)
                existedPatient.Patronymic = patient.Patronymic;

            if (patient.Address is not null)
                existedPatient.Address = patient.Address;

            if (patient.BirthDate.HasValue)
                existedPatient.BirthDate = DateOnly.FromDateTime(patient.BirthDate.Value);

            if (patient.Sex.HasValue)
                existedPatient.Sex = patient.Sex.Value;

            await CheckAndFillReferencesProperties(existedPatient, patient.SiteId);

            await _context.SaveChangesAsync();
        }

        private async Task CheckAndFillReferencesProperties(Patient existedPatient, long? siteId)
        {
            if (siteId is not null)
            {
                var site = await _context.HospitalSites.FirstOrDefaultAsync(s => s.Id == siteId);

                if (site is null)
                    throw new KeyNotFoundException();

                existedPatient.Site = site;
            }
        }
    }
}
