using Hospital.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            return Ok(_context.Patients
                .Include(c => c.VitalSigns)
                .Include(c => c.MedicalNotes));
                 
                //.ThenInclude(d => d.Cities));
        }
    }


}
