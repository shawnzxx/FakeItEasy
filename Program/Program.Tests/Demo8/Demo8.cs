using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo08;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo8
{
    public class When_creating_a_customer_which_has_an_invalid_address
    {
        //verify that specific parameter values are passed to the mock object
        [Fact]
        public void an_exception_should_be_raised()
        {
            //Arrange
            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeCustomerAddressFactory = A.Fake<ICustomerAddressFactory>();

            A.CallTo(
                () => fakeCustomerAddressFactory.From(A<CustomerToCreateDto>.Ignored))
                .Throws(new InvalidCustomerAddressException());

            var customerService = new CustomerService(
                fakeCustomerRepository,
                fakeCustomerAddressFactory);

            //Act
            Action act = () => customerService.Create(new CustomerToCreateDto());

            //Assert
            Assert.Throws<CustomerCreationException>(act);
        }
    }
}
