namespace PluralSight.FakeItEasy.Code.Demo09
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        string LocalTimeZone { get; set; }
    }
}