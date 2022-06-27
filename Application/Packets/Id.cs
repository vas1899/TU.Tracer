using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{
    public class Id
    {
        public class Query : IRequest<Result<Packet>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Packet>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Packet>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Packets.FindAsync(request.Id);

                return Result<Packet>.Success(result);
            }
        }
    }
}
