using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoHeartcoreHooks.Models;

namespace UmbracoHeartcoreHooks.Controllers
{
    public class HooksApiController : UmbracoApiController
    {
        private const string HookSite = "HookSite";

        private IKeyValueService keyValueService;
        public HooksApiController(IKeyValueService keyValueService)
        {
               this.keyValueService = keyValueService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Save([FromBody] HookConfiguration config)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            this.keyValueService.SetValue(HookSite, config.Site);

            return Ok();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            string? site = this.keyValueService.GetValue(HookSite);

            if (site.HasValue())
            {
                return Ok(site);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
