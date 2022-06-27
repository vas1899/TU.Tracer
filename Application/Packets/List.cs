using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{
    public class List
    {
        public class Query : IRequest<Result<List<Packet>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Packet>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Packet>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Packets = await _context.Packets.ToListAsync(cancellationToken);
                return Result<List<Packet>>.Success(Packets);
            }
        }
    }
}