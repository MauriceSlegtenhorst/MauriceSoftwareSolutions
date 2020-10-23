using MSS.Domain.Common.Interfaces;
using System;

namespace MSS.Domain.Concrete.DatabaseEntities.Credit
{
    public sealed class Credit : IEntity
    {
        public string Id { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public DateTime? ModificationDateUTC { get; set; }

        public string CreditCategoryFK { get; set; }
        public CreditCategory CreditCategory { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string HTMLDescription { get; set; }
        public string HTMLMadeBy { get; set; }
        public string HTMLGotFrom { get; set; }
        public string LinkToImage { get; set; }
    }
}
