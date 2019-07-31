using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo06;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo6
{
    public class When_creating_a_customer
    {
        //verify that specific parameter values are passed to the mock object
        [Fact]
        public void a_full_name_should_be_created_from_first_and_last_name()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto
            {
                FirstName = "Bob",
                LastName = "Builder"
            };

            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeFullNameBuilder = A.Fake<ICustomerFullNameBuilder>();

            var customerService = new CustomerService(
                fakeCustomerRepository, fakeFullNameBuilder);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            A.CallTo(
                () => fakeFullNameBuilder.From(
                    A<string>.That.Matches(s => s.Equals(customerToCreateDto.FirstName)),
                    A<string>.That.Matches(s => s.Equals(customerToCreateDto.LastName))))
            .MustHaveHappened();
        }
    }
}
