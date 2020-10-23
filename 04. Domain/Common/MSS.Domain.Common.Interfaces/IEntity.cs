using System;

namespace MSS.Domain.Common.Interfaces
{
    public interface IEntity
    {
        public string Id { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public DateTime? ModificationDateUTC { get; set; }
    }
}
