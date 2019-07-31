using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo09;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo9
{
    public class When_creating_a_customer
    {
        //verify that specific parameter values are passed to the mock object
        [Fact]
        public void the_local_timezone_should_be_set()
        {
            //Arrange
            var fakeCustomerRepository = A.Fake<ICustomerRepository>();

            var customerService = new CustomerService(
                fakeCustomerRepository);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            Assert.NotEmpty(fakeCustomerRepository.LocalTimeZone);
            Assert.NotNull(fakeCustomerRepository.LocalTimeZone);

        }
    }
}
