using MSS.Application.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace MSS.Persistence.ObjectRelationalMapping.Tests.Shared
{
    public class UnitOfWorkTests
    {
        private IUnitOfWork _unitOfWork;
        public UnitOfWorkTests(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public void DpInjectionWorks()
        {
            Assert.NotNull(_unitOfWork);
        }

        [Fact]
        public async void SaveAsync_ShouldSave()
        {
            await _unitOfWork.SaveAsync(CancellationToken.None);
        }

        // TODO Test with cancellationToken shizzlemanizle
    }
}
