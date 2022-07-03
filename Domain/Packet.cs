using System;

namespace Domain
{
    public class Packet
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public bool IsDelivered { get; set; }

    }
}
