using IDataInterface;
using System;
using Library;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class StructureAPI
    {
        private IIsleManager isleManager;
        private IShelfManager shelfManager;
        private IBookManager bookManager;

        public StructureAPI(IIsleManager isleManager)
        {
            this.isleManager = isleManager;
            
        }
        public bool AddIsle(int isleNumber)
        {
            var existingIsle = isleManager.GetIsleByIsleNumber(isleNumber);
            if (existingIsle != null)
                return false;
            isleManager.AddIsle(isleNumber);
            return true;
        }

        public StructureAPI(IShelfManager shelfManager)
        {
            this.shelfManager = shelfManager;
        }
        public bool AddShelf(int shelfNumber)
        {
            var existingShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (existingShelf != null)
                return false;
            shelfManager.AddShelf(shelfNumber);
            return true;
        }

        public StructureAPI(IIsleManager isleManager, IShelfManager shelfManager)
        {
            this.isleManager = isleManager;
            this.shelfManager = shelfManager;

        }
        public RemoveIsleErrorCodes RemoveIsle(int isleNumber)
        {
            var newIsle = isleManager.GetIsleByIsleNumber(isleNumber);
            if (newIsle == null)
                return RemoveIsleErrorCodes.NoSuchIsle;
            if (newIsle.Shelves.Count > 0)
                return RemoveIsleErrorCodes.IsleHasShelves;

            isleManager.RemoveIsle(newIsle.IsleID);

            return RemoveIsleErrorCodes.Ok;
        }

        public MoveShelfErrorCodes MoveShelf(int shelfNumber, int isleNumber)
        {
            var newIsle = isleManager.GetIsleByIsleNumber(isleNumber);
            if (newIsle == null)
                return MoveShelfErrorCodes.NoSuchIsle;

            var shelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (shelf == null)
                return MoveShelfErrorCodes.NoSuchShelf;
            if (shelf.Isle.IsleNumber == isleNumber)
                return MoveShelfErrorCodes.ShelfAlreadyOnThatIsle;

            shelfManager.MoveShelf(shelf.ShelfID, newIsle.IsleID);

            return MoveShelfErrorCodes.Ok;
        }

            public StructureAPI(IShelfManager shelfManager, IBookManager bookManager)
        {
            
            this.shelfManager = shelfManager;
            this.bookManager = bookManager;

        }
        public RemoveShelfErrorCodes RemoveShelf(int shelfNumber)
        {
            var newShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (newShelf == null)
                return RemoveShelfErrorCodes.NoSuchShelf;
            if (newShelf.Books.Count > 0)
                return RemoveShelfErrorCodes.ShelfHasBook;

            shelfManager.RemoveShelf(newShelf.ShelfID);

            return RemoveShelfErrorCodes.Ok;
        }

        public MoveBookErrorCodes MoveBook(int bookNumber, int shelfNumber)
        {
            var newShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (newShelf == null)
                return MoveBookErrorCodes.NoSuchShelf;

            var book = bookManager.GetBookByBookNumber(bookNumber);
            if (book == null)
                return MoveBookErrorCodes.NoSuchBook;
            if (book.Shelf.ShelfNumber == shelfNumber)
                return MoveBookErrorCodes.BookAlreadyOnThatShelf;

            bookManager.MoveBook(book.BookID, newShelf.ShelfID);

            return MoveBookErrorCodes.Ok;
        }
        public StructureAPI(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        public bool AddBook(int bookNumber)
        {
            var existingBook = bookManager.GetBookByBookNumber(bookNumber);
            if (existingBook != null)
                return false;
            bookManager.AddBook(bookNumber);
            return true;
        }

    }

}

