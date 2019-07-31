using FakeItEasy;
using PluralSight.FakeItEasy.Code.Demo01;
using System;
using Xunit;

namespace Program.Tests.Demo1
{
    public class When_creating_a_customer
    {
        [Fact]
        public void the_repository_save_should_be_called()
        {
            //Arrange
            var fakeRepository = A.Fake<ICustomerRepository>();

            var service = new CustomerService(fakeRepository);

            //Act
            service.Create(new CustomerToCreateDto());

            //Assert
            A.CallTo(
                () => fakeRepository.Save(A<Customer>.Ignored))
                .MustHaveHappened();
        }
    }
}
