using FakeItEasy;
using PluralSight.FakeItEasy.Code.Demo03;
using System;
using System.Collections.Generic;
using Xunit;

namespace Program.Tests.Demo3
{
    public class When_creating_a_new_customer
    {
        //this shows how setting the return value will 
        //change the execution flow
        [Fact]
        public void an_exception_should_be_thrown_if_the_address_is_not_created()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto
            { FirstName = "Bob", LastName = "Builder" };
            var fakeAddressBuilder = A.Fake<ICustomerAddressBuilder>();
            var fakeRepository = A.Fake<ICustomerRepository>();

            A.CallTo(
                () => fakeAddressBuilder.From(A<CustomerToCreateDto>.Ignored))
                .Returns(null);

            var customerService = new CustomerService(fakeAddressBuilder, fakeRepository);

            //Act
            Action act = () => customerService.Create(customerToCreateDto);

            //Assert
            Assert.Throws<InvalidCustomerMailingAddressException>(act);
        }

        [Fact]
        public void the_customer_should_be_saved_if_the_address_was_created()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto { FirstName = "Bob", LastName = "Builder" };

            var fakeRepository = A.Fake<ICustomerRepository>();
            var fakeAddressBuilder = A.Fake<ICustomerAddressBuilder>();

            A.CallTo(
                () => fakeAddressBuilder.From(A<CustomerToCreateDto>.Ignored))
                .Returns(new Address());

            var customerService = new CustomerService(fakeAddressBuilder, fakeRepository);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            A.CallTo(
                () => fakeRepository.Save(A<Customer>.Ignored))
                .MustHaveHappened();

        }
    }
}
