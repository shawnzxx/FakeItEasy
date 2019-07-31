using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo12;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo12
{
    public class When_creating_a_new_customer
    {
        //verify that specific parameter values are passed to the mock object
        [Fact]
        public void an_email_should_be_sent_to_the_sales_team()
        {
            //Arrange
            var fakeCustomerRepository = A.Fake<ICustomerRepository>();
            var fakeMailingRepository = A.Fake<IMailingRepository>();

            var customerService = new CustomerService(
                fakeCustomerRepository, fakeMailingRepository);

            //Act
            fakeCustomerRepository.NotifySalesTeam +=
                Raise.With(new NotifySalesTeamEventArgs("asdf"));

            //Assert
            A.CallTo(
                () => fakeMailingRepository.NewCustomerMessage(
                    A<string>.Ignored));
        }
    }
}
