using Hospital.API.Contracts;
using Hospital.Application.Interfaces;
using Hospital.Logic.Models;
using Hospital.Logic.Store;
using Hospital.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ApplicationContext _dbContext;

        public PatientController(IPatientService patientService, ApplicationContext dbContext)
        {
            _patientService = patientService;
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(long id) 
        {
            var patient = await _patientService.GetById(id);

            var patientResponse = new EditPatientResponse(
                patient.Id,
                patient.Surname,
                patient.Name,
                patient.Patronymic,
                patient.Address,
                patient.BirthDate,
                patient.Sex,
                patient.HospitalSiteId
                );

            return Ok(patientResponse);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSortedByPage(string sortedFilter = "id", int page = 0)
        {
            var patients = await _patientService.GetSortedByPage(sortedFilter, page);

            var patientsResponse = patients.Select(p => 
                new FormPatientResponse(
                    p.Id,
                    p.Surname,
                    p.Name,
                    p.Patronymic,
                    p.Address,
                    p.BirthDate,
                    p.Sex,
                    p.Site.Number
                    )
                )
                .ToList();

            return Ok(patientsResponse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(PatientCreate request)
        {
            await _patientService.Add(request);

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(long patientId, PatientUpdate request)
        {
            await _patientService.Update(patientId, request);

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(long id)
        {
            await _patientService.Delete(id);

            return Ok();
        }
    }
}
