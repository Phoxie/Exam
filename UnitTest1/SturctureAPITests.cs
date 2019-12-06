using System;
using System.Collections.Generic;
using IDataInterface;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace UnitTest1
{
    [TestClass]
    public class StructureAPITests
    {
        [TestMethod]
        public void TestAddIsle()
        {
            var structureManagerMock = new Mock<IIsleManager>();

            structureManagerMock.Setup(m =>
                m.GetIsleByIsleNumber(It.IsAny<int>()))
                .Returns<Isle>(null);

            structureManagerMock.Setup(m =>
                m.AddIsle(It.IsAny<int>()));

            var structureAPI = new StructureAPI(structureManagerMock.Object);
            var successfull = structureAPI.AddIsle(1);
            Assert.IsTrue(successfull);
            structureManagerMock.Verify(
                m => m.AddIsle(It.Is<int>(i => i == 1)),
            Times.Once());
        }
        [TestMethod]
        public void RemoveEmptyIsle()
        {
            var isleManagerMock = new Mock<IIsleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            isleManagerMock.Setup(m =>
               m.GetIsleByIsleNumber(It.IsAny<int>()))
                .Returns(new Isle
                {
                    IsleNumber = 4,
                    Shelves = new List<Shelf>()
                });

            var structureAPI = new StructureAPI(isleManagerMock.Object, shelfManagerMock.Object);
            var successfull = structureAPI.RemoveIsle(4);
            Assert.AreEqual(RemoveIsleErrorCodes.Ok, successfull);
            isleManagerMock.Verify(
                m => m.RemoveIsle(It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void RemoveIsleWithOneShelf()
        {
            var isleManagerMock = new Mock<IIsleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            isleManagerMock.Setup(m =>
               m.GetIsleByIsleNumber(It.IsAny<int>()))
                .Returns(new Isle
                {
                    IsleNumber = 4,
                    Shelves = new List<Shelf>()
                    {
                        new Shelf()
                    }
                });

            var structureAPI = new StructureAPI(isleManagerMock.Object, shelfManagerMock.Object);
            var successfull = structureAPI.RemoveIsle(4);
            Assert.AreEqual(RemoveIsleErrorCodes.IsleHasShelves, successfull);
            isleManagerMock.Verify(
                m => m.RemoveIsle(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void RemoveNonexistingIsle()
        {
            var isleManagerMock = new Mock<IIsleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            isleManagerMock.Setup(m =>
               m.GetIsleByIsleNumber(It.IsAny<int>()))
                .Returns((Isle)null);

            var structureAPI = new StructureAPI(isleManagerMock.Object, shelfManagerMock.Object);
            var successfull = structureAPI.RemoveIsle(4);
            Assert.AreEqual(RemoveIsleErrorCodes.NoSuchIsle, successfull);
            isleManagerMock.Verify(
                m => m.RemoveIsle(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestAddShelf()
        {
            var structureManagerMock = new Mock<IShelfManager>();

            structureManagerMock.Setup(m =>
              m.GetShelfByShelfNumber(It.IsAny<int>()))
            .Returns<Shelf>(null);

            structureManagerMock.Setup(m =>
                m.AddShelf(It.IsAny<int>()));

            var structureAPI = new StructureAPI(structureManagerMock.Object);
            var successfull = structureAPI.AddShelf(1);
            Assert.IsTrue(successfull);
            structureManagerMock.Verify(
                m => m.AddShelf(It.Is<int>(i => i == 1)),
            Times.Once());
        }
        [TestMethod]
        public void RemoveEmptyShelf()
        {
            var shelfManagerMock = new Mock<IShelfManager>();
            var bookManagerMock = new Mock<IBookManager>();

            shelfManagerMock.Setup(m =>
               m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf
                {
                    ShelfNumber = 4,
                    Books = new List<Book>()
                });

            var structureAPI = new StructureAPI(shelfManagerMock.Object, bookManagerMock.Object);
            var successfull = structureAPI.RemoveShelf(4);
            Assert.AreEqual(RemoveShelfErrorCodes.Ok, successfull);
            shelfManagerMock.Verify(
                m => m.RemoveShelf(It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void RemoveShelfWithOneBook()
        {
            
            var shelfManagerMock = new Mock<IShelfManager>();
            var bookManagerMock = new Mock<IBookManager>();

            shelfManagerMock.Setup(m =>
               m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf
                {
                    ShelfNumber = 4,
                    Books = new List<Book>()
                    {
                        new Book()
                    }
                });

            var structureAPI = new StructureAPI(shelfManagerMock.Object, bookManagerMock.Object);
            var successfull = structureAPI.RemoveShelf(4);
            Assert.AreEqual(RemoveShelfErrorCodes.ShelfHasBook, successfull);
            shelfManagerMock.Verify(
                m => m.RemoveShelf(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void RemoveNonexistingShelf()
        {
           
            var shelfManagerMock = new Mock<IShelfManager>();
            var bookManagerMock = new Mock<IBookManager>();

            shelfManagerMock.Setup(m =>
               m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns((Shelf)null);

            var structureAPI = new StructureAPI(shelfManagerMock.Object, bookManagerMock.Object);
            var successfull = structureAPI.RemoveShelf(4);
            Assert.AreEqual(RemoveShelfErrorCodes.NoSuchShelf, successfull);
            shelfManagerMock.Verify(
                m => m.RemoveShelf(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void MoveShelfOk()
        {
            var isleManagerMock = new Mock<IIsleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            isleManagerMock.Setup(m =>
               m.GetIsleByIsleNumber(It.IsAny<int>()))
                .Returns(new Isle { IsleID = 2 });

            shelfManagerMock.Setup(m =>
              m.GetShelfByShelfNumber(It.IsAny<int>()))
               .Returns(new Shelf
               {
                   ShelfID = 2,
                   Isle = new Isle()
               });

            var structureAPI = new StructureAPI(isleManagerMock.Object, shelfManagerMock.Object);
            var result = structureAPI.MoveShelf(1, 1);
            Assert.AreEqual(MoveShelfErrorCodes.Ok, result);
            shelfManagerMock.Verify(m =>
                m.MoveShelf(2, 2), Times.Once());
        }

        [TestMethod]
         public void TestAddBook()
         {
             var structureManagerMock = new Mock<IBookManager>();

             structureManagerMock.Setup(m =>
                 m.GetBookByBookNumber(It.IsAny<int>()))
             .Returns<Book>(null);

             structureManagerMock.Setup(m =>
                 m.AddBook(It.IsAny<int>()));

             var structureAPI = new StructureAPI(structureManagerMock.Object);
             var successfull = structureAPI.AddBook(1);
             Assert.IsTrue(successfull);
             structureManagerMock.Verify(
                 m => m.AddBook(It.Is<int>(i => i == 1)),
             Times.Once());
         }

        [TestMethod]
        public void MoveBookOk()
        {
            var shelfManagerMock = new Mock<IShelfManager>();
            var bookManagerMock = new Mock<IBookManager>();

            shelfManagerMock.Setup(m =>
               m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf { ShelfID = 2 });

            bookManagerMock.Setup(m =>
              m.GetBookByBookNumber(It.IsAny<int>()))
               .Returns(new Book
               {
                   BookID = 2,
                   Shelf = new Shelf()
               });

            var structureAPI = new StructureAPI(shelfManagerMock.Object, bookManagerMock.Object);
            var result = structureAPI.MoveBook(1, 1);
            Assert.AreEqual(MoveBookErrorCodes.Ok, result);
            bookManagerMock.Verify(m =>
                m.MoveBook(2, 2), Times.Once());
        }
    } 
}

      

