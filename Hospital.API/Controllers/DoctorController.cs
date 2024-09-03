using Hospital.API.Contracts;
using Hospital.Application.Interfaces;
using Hospital.Application.Services;
using Hospital.Logic.Models;
using Hospital.Logic.Store;
using Hospital.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly ApplicationContext _dbContext;

        public DoctorController(IDoctorService doctorService, ApplicationContext dbContext)
        {
            _doctorService = doctorService;
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(long id)
        {
            var doctor = await _doctorService.GetById(id);

            var doctorResponse = new EditDoctorResponse(
                doctor.Id,
                doctor.FullName,
                doctor.OfficeId,
                doctor.SpecializationId,
                doctor.HospitalSiteId
                );
            return Ok(doctorResponse);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSortedByPage(string sortedFilter = "id", int page = 0)
        {
            var doctors = await _doctorService.GetSortedByPage(sortedFilter, page);

            var doctorsResponse = doctors.Select(d =>
                new FormDoctorResponse(
                    d.Id,
                    d.FullName,
                    d.Office.Number,
                    d.Specialization.Name,
                    d.Site is null ? null : d.Site.Number
                    )
                )
                .ToList();

            return Ok(doctorsResponse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(DoctorCreate request)
        {
            await _doctorService.Add(request);

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(long doctorId, DoctorUpdate request)
        {
            await _doctorService.Update(doctorId, request);

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(long id)
        {
            await _doctorService.Delete(id);

            return Ok();
        }
    }
}
