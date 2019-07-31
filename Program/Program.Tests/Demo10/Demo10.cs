using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo10;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo10
{

    public class When_creating_a_customer
    {
        [Fact]
        public void the_workstation_id_should_be_used()
        {
            //Arrange
            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeApplicationSettings = A.Fake<IApplicationSettings>();

            A.CallTo(() => fakeApplicationSettings.WorkstationId).Returns(123);

            var customerService = new CustomerService(
                fakeCustomerRepository,
                fakeApplicationSettings);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            A.CallTo(
                () => fakeApplicationSettings.WorkstationId)
                .MustHaveHappened();
        }
    }
}
