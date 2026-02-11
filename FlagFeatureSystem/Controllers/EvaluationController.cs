using Flag.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flags.API.Controllers
{
    [ApiController]
    [Route("api/features")]
    public class EvaluationController : ControllerBase
    {
        private readonly FeatureEvaluator _evaluator;

        public EvaluationController(FeatureEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        [HttpGet("evaluate")]
        public bool Evaluate(
            string key,
            string? user,
            string? group,
            string? region)
        {
            return _evaluator.IsEnabled(key, user, group, region);
        }
    }
}
