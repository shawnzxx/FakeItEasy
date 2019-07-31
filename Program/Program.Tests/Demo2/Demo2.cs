using FakeItEasy;
using PluralSight.FakeItEasy.Code.Demo02;
using System;
using System.Collections.Generic;
using Xunit;

namespace Program.Tests.Demo2
{
    public class When_creating_a_new_customer
    {
        [Fact]
        //shows how to verify that a method was called 
        //an explicit number of times
        public void the_customer_repository_should_be_called_once_per_customer()
        {
            //Arrange
            var listOfCustomerDtos = new List<CustomerToCreateDto>
                    {
                        new CustomerToCreateDto
                            {
                                FirstName = "Sam", LastName = "Sampson"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Bob", LastName = "Builder"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Doug", LastName = "Digger"
                            }
                    };

            var fakeRepository = A.Fake<ICustomerRepository>();

            var customerService = new CustomerService(fakeRepository);

            //Act
            customerService.Create(listOfCustomerDtos);

            //Assert
            A.CallTo(
                () => fakeRepository.Save(A<Customer>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Times(3));
        }
    }
}
