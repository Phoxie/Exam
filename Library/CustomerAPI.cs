using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CustomerAPI
    {
        private ICustomerManager customerManager;


        public CustomerAPI(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;

        }
        public bool AddCustomer(int customerNumber)
        {
            var existingCustomer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (existingCustomer != null)
                return false;
            customerManager.AddCustomer(customerNumber);
            return true;
        }

        public RemoveCustomerErrorCodes RemoveCustomer(int customerNumber)
        {
            var newCustomer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (newCustomer == null)
                return RemoveCustomerErrorCodes.NoSuchCustomer;

            customerManager.RemoveCustomer(newCustomer.CustomerID);

            return RemoveCustomerErrorCodes.Ok;
        }
    }
}

