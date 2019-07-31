namespace PluralSight.FakeItEasy.Code.Demo03
{
    public interface ICustomerAddressBuilder
    {
        Address From(CustomerToCreateDto customerToCreate);
    }
}