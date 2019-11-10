using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.NetCore.Template.Api.Dto;
using WebApi.NetCore.Template.DAL;

namespace WebApi.NetCore.Template.Api.Controllers
{
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork, ILogger<TestController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestModelDto>>> Get()
        {
            _logger.LogTrace("Trace Logging");
            _logger.LogDebug("Debug Logging");
            _logger.LogInformation("Info Logging");
            _logger.LogWarning("Warning Logging");
            _logger.LogError("Error Logging");
            var models = await _unitOfWork.TestModelRepository.DbSet.ToListAsync();

            var dtos = models.Select(TestModelDto.FromTestModel);

            return new OkObjectResult(dtos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TestModelDto dto)
        {
            var model = TestModelDto.ToTestModel(dto);

            await _unitOfWork.TestModelRepository.DbSet.AddAsync(model);

            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}