using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.Models.ViewModels;

namespace SampleApplication.Controllers
{
    [Route("/api/[controller]")]
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly ILogger<PieController> _logger;

        public PieController(ILogger<PieController> logger,
            IPieRepository pieRepository, 
            ICategoryRepository categoryRepository,
            IBillingRepository billingRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _billingRepository = billingRepository;
            _logger = logger;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);
            var pieListViewModel = new PieListViewModal(_pieRepository.AllPies, "Chese Cakes");

            return View(pieListViewModel);

        }

        [HttpGet("allpies")]
        [Produces("application/json")]
        public async Task<IEnumerable<Pie>> getAllPies()
        {
            return await Task.FromResult(_pieRepository.AllPies);
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Pie>> getPieById(int id)
        {
            try
            {
                var result = await Task.FromResult(_pieRepository.GetPieById(id));

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown while fetching pie by id");
                return Problem($"Exception thrown: {ex.Message}");
            }

        }

        [HttpGet("getemployee")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Employee>>> getCustomers()
        {
            try
            {
                var result = await _billingRepository.GetEmployees();
                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown while fetching employees");
                return Problem($"Exception thrown: {ex.Message}");
            }
        }
    }

}