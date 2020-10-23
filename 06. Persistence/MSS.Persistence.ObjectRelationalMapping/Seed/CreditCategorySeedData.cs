using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

using MSS.Domain.Concrete.DatabaseEntities.Credit;
using System;
using System.Collections.ObjectModel;

namespace MSS.Persistence.ObjectRelationalMapping.Seed
{
    internal sealed class CreditCategorySeedData
    {
        private CreditCategorySeedData() { }

        internal static CreditCategory[] Build()
        {
            return new CreditCategory[]
            {
                new CreditCategory
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Don't reinvent the wheel",
                    SubTitle = "Sources that made UI development easier",
                    Credits = new Collection<DomainCredit>()
                },
                new CreditCategory
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Food for the brain",
                    SubTitle = "Sources that helped me gaining knowledge  about programming related subjects",
                    Credits = new Collection<DomainCredit>()
                }
            };
        }
    }
}
