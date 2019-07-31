using FakeItEasy;
using PluralSight.FakeItEasy.Code.Demo04;
using System;
using System.Collections.Generic;
using Xunit;

namespace Program.Tests.Demo4
{
    public class When_creating_a_customer
    {
        //this shows how setting the return value will 
        //change the execution flow
        [Fact]
        public void the_customer_should_be_persisted()
        {
            //Arrange
            var mockCustomerRepository = A.Fake<ICustomerRepository>();
            var mockMailingAddressFactory = A.Fake<IMailingAddressFactory>();

            MailingAddress returnedMailingAddress;
            A.CallTo(
                () => mockMailingAddressFactory.TryParse(
                    A<string>.Ignored, out returnedMailingAddress))
                .Returns(true)
                .AssignsOutAndRefParameters(new MailingAddress());


            var customerService = new CustomerService(
                mockCustomerRepository, mockMailingAddressFactory);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            A.CallTo(() => mockCustomerRepository.Save(A<Customer>.Ignored));
        }
    }
}
