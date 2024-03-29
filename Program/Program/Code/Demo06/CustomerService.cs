﻿namespace PluralSight.FakeItEasy.Code.Demo06
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFullNameBuilder _customerFullName;

        public CustomerService(
            ICustomerRepository customerRepository, 
            ICustomerFullNameBuilder customerFullName)
        {
            _customerRepository = customerRepository;
            _customerFullName = customerFullName;
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var fullName = _customerFullName.From(
                customerToCreateDto.FirstName,
                //"asdf",   //uncomment this for test failed
                customerToCreateDto.LastName);

            var customer = new Customer(fullName);

            _customerRepository.Save(customer);
        }
    }
}