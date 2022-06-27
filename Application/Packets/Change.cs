using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{
    public class Change
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Packet Packet { get; set; }
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
                if (Packet == null)
                {
                    return null;
                }

                _mapper.Map(command.Packet, Packet);
                bool isPacketModified = await _context.SaveChangesAsync() > 0;

                if (isPacketModified)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                else
                {
                    return Result<Unit>.Failure("Could not modify an Packet!");
                }
            }
        }
    }

}
