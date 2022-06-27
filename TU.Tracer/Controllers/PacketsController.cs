using Application.Packets;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TU.Tracer.Controllers
{
    public class PacketsController : BaseApiController
    {
        // GET: api/Packets/5
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Id(Guid id)
        {
            return HandleResult(await Mediator.Send(new Id.Query { Id = id }));
        }

        // GET: api/Packets
        [HttpGet]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new List.Query(), ct));
        }

        // POST: api/Packets
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Packet Packet, CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Packet = Packet }, ct));
        }

        // PUT: api/Packets/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Change(Guid id, [FromBody] Packet Packet, CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new Change.Command { Packet = Packet, Id = id }, ct));
        }

        // DELETE api/Packets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }, ct));
        }
    }
}
