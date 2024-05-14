using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperience(int id, int years)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, years);

                return Ok(doctor);
            }
            catch (NoSuchDoctorException nsde)
            {
                return NotFound(nsde.Message);
            }
        }

        [HttpGet("specialization/{specialization}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsBySpecialization(string specialization)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpecialization(specialization);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
