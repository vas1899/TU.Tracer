using Application.Workdays;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TU.Tracer.Controllers
{
    public class WorkdaysController : BaseApiController
    {

        // GET: api/Workdays
        [HttpGet]
        public async Task<ActionResult<List<Workday>>> List(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        }
    }
}
