using Domain;
using FluentValidation;

namespace Application.Packets
{
    public class PacketValidator : AbstractValidator<Packet>
    {
        public PacketValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}