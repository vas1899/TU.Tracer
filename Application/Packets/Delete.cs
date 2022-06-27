using Application.Core;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{

    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var Packet = await _context.Packets.FindAsync(request.Id);
                if (Packet == null)
                {
                    return null;
                }
                _context.Packets.Remove(Packet);
                bool isPacketDeleted = await _context.SaveChangesAsync() > 0;

                if (isPacketDeleted)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                else
                {
                    return Result<Unit>.Failure("Could not delete an Packet!");
                }
            }
        }
    }

}
