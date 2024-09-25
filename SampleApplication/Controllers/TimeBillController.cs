using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{


    [Route("/api/[controller]")]
    public class TimeBillController : Controller
    {
        private BillingRepository _billingRepository;

        public TimeBillController(BillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<TimeBill?>> GetTimeBills(int id)
        {
            var bill = await _billingRepository.GetTimeBill(id);
            if (bill is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bill);
            }
        }

        [HttpPost("")]
        [Produces("application/json")]
        public async Task<ActionResult> SaveTimeBill(TimeBill model)
        {
            _billingRepository.AddEntity<TimeBill>(model);

            if (await _billingRepository.SaveChanges())
            {
                return CreatedAtRoute("GetTimeBills", new { id = model.Id }, model);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
