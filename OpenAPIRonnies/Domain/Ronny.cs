using System;

namespace OpenAPIRonnies.Domain
{
    public class Ronny
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}