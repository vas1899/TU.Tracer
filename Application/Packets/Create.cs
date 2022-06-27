using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packets
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Packet Packet { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Packet).SetValidator(new PacketValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command command, CancellationToken cancellationToken)
            {
                _context.Packets.Add(command.Packet);
                bool isPacketCreated = await _context.SaveChangesAsync() > 0;

                if (isPacketCreated)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                else
                {
                    return Result<Unit>.Failure("Could not create Packet!");
                }
            }
        }
    }
}
