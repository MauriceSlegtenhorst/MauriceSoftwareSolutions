using MSS.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace MSS.Domain.Concrete.DatabaseModels.Credit
{
    public sealed class CreditCategory : IEntity
    {
        public string Id { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public DateTime? ModificationDateUTC { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public ICollection<Credit> Credits { get; set; }
    }
}
