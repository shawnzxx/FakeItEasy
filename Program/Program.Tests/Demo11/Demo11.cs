using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo11;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo11
{

    public class When_creating_a_customer
    {
        [Fact]
        public void the_workstationid_should_be_retrieved()
        {
            //Arrange
            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeApplicationSettings = A.Fake<IApplicationSettings>();

            A.CallTo(() => fakeApplicationSettings
                                .SystemConfiguration
                                .AuditingInformation
                                .WorkstationId)
                           .Returns(1234);

            var customerService = new CustomerService(
                                        fakeCustomerRepository,
                                        fakeApplicationSettings);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            A.CallTo(
                () => fakeApplicationSettings
                        .SystemConfiguration
                        .AuditingInformation
                        .WorkstationId)
                .MustHaveHappened();
        }
    }
}
