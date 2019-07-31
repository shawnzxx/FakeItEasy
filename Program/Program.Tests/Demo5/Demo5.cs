using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo05;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo5
{
    public class When_creating_a_customer
    {
        [Fact]
        //returning different values on subsequent calls
        public void each_customer_should_be_assigned_an_id()
        {
            //Arrange
            var listOfCustomersToCreate = new List<CustomerToCreateDto>
                                                  {
                                                      new CustomerToCreateDto(),
                                                      new CustomerToCreateDto()
                                                  };

            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeIdFactory = A.Fake<IIdFactory>();

            A.CallTo(
                () => fakeIdFactory.Create())
                .ReturnsNextFromSequence(1, 2, 3, 4, 5, 6);


            var customerService = new CustomerService(
                fakeCustomerRepository, fakeIdFactory);

            //Act
            customerService.Create(listOfCustomersToCreate);

            //Assert
            A.CallTo(() => fakeIdFactory.Create()).MustHaveHappened(Repeated.AtLeast.Once);
        }
    }
}
