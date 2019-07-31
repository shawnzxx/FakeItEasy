using System;
using System.Collections.Generic;
using PluralSight.FakeItEasy.Code.Demo13;
using System.Text;
using Xunit;
using FakeItEasy;

namespace Program.Tests.Demo13
{
    public class When_formatting_a_customers_name
    {
        //verify that specific parameter values are passed to the mock object
        [Fact]
        public void all_bad_words_should_be_scrubbed()
        {
            //Arrange
            var fakeCustomerNameFormatter =
                A.Fake<CustomerNameFormatter>();

            //Act
            fakeCustomerNameFormatter.From(new Customer());

            //Assert
            A.CallTo(fakeCustomerNameFormatter)
                .Where(x => x.Method.Name == "ParseBadWordsFrom")
                .MustHaveHappened(Repeated.Exactly.Twice);
        }
    }
}
