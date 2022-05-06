using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Validator;
using WebApi.Dto.Test;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IEnumerable<IValidator<TestDTO>> _validators;

        public TestController(IEnumerable<IValidator<TestDTO>> validators)
        {
            _validators = validators;
        }

        [HttpGet("validators")]
        public IEnumerable<IValidator<TestDTO>> GetTestDtoValidators()
        {
            return _validators;
        }
    }
}