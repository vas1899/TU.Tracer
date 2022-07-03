using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{
    public class MarkDelivered
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command command, CancellationToken cancellationToken)
            {
                var Packet = await _context.Packets.FindAsync(command.Id);
                if (Packet == null) {
                    return null;
                }
                if (Packet.IsDelivered) {
                    return Result<Unit>.Failure("Already marked as delivered");

                }
                Packet.IsDelivered = true;

                bool isPacketModified = await _context.SaveChangesAsync() > 0;

                if (isPacketModified) {
                    return Result<Unit>.Success(Unit.Value);
                }
                else {
                    return Result<Unit>.Failure("Could not modify an Packet!");
                }
            }
        }
    }
}
