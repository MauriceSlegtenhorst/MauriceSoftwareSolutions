using MSS.Domain.Common.Interfaces;
using System;

namespace MSS.Domain.Concrete.DatabaseModels.Credit
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
        public string Description { get; set; }
        public string MadeBy { get; set; }
        public string GotFrom { get; set; }
        public string LinkToImage { get; set; }
    }
}
