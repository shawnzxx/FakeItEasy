using System;

namespace PluralSight.FakeItEasy.Code.Demo08
{
    public class CustomerCreationException : Exception
    {
        public CustomerCreationException(Exception exception):base("error",exception)
        {
            
        }
    }
}