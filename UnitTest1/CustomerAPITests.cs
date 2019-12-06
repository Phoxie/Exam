using System;
using System.Collections.Generic;
using IDataInterface;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class CustomerAPITests
    {
        [TestMethod]
        public void TestAddCustomer()
        {
            var customerManagerMock = new Mock<ICustomerManager>();

            customerManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                .Returns<Customer>(null);

            customerManagerMock.Setup(m =>
                m.AddCustomer(It.IsAny<int>()));

            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.AddCustomer(1);
            Assert.IsTrue(successfull);
            customerManagerMock.Verify(
                m => m.AddCustomer(It.Is<int>(i => i == 1)),
            Times.Once());
        }
        [TestMethod]

        public void RemoveCustomer()
        {
            var customerManagerMock = new Mock<ICustomerManager>();


            customerManagerMock.Setup(m =>
               m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                .Returns(new Customer
                {
                    CustomerNumber = 4
                }) ;

            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.RemoveCustomer(4);
            Assert.AreEqual(RemoveCustomerErrorCodes.Ok, successfull);
            customerManagerMock.Verify(
                m => m.RemoveCustomer(It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void RemoveNonexistingCustomer()
        {
            var customerManagerMock = new Mock<ICustomerManager>();


            customerManagerMock.Setup(m =>
               m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                .Returns((Customer)null);

            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.RemoveCustomer(4);
            Assert.AreEqual(RemoveCustomerErrorCodes.NoSuchCustomer, successfull);
            customerManagerMock.Verify(
                m => m.RemoveCustomer(It.IsAny<int>()), Times.Never);
        }
    }
}
