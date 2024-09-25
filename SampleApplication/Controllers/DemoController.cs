using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class DemoController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public DemoController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet("/allpies2")]
        public async Task<IEnumerable<Pie>> getAllPies()
        {
            return await Task.FromResult(_pieRepository.AllPies);
        }
    }
}
