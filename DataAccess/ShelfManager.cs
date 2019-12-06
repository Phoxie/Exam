using IDataInterface;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShelfManager : IShelfManager

    {
        

        public void AddShelf(int shelfNumber)
        {
            using var context = new LibraryContext();

            var shelf = new Shelf();
            shelf.ShelfNumber = shelfNumber;

            context.Shelves.Add(shelf);
            context.SaveChanges();
        }

        

        public Shelf GetShelfByShelfNumber(int shelfNumber)
        {
            using var context = new LibraryContext();
            return (from s in context.Shelves
                    where s.ShelfNumber == shelfNumber
                    select s)
                    .Include(s => s.Isle)
                    .FirstOrDefault();
        }


        public void MoveShelf(int shelfID, int isleID)
        {
            using var context = new LibraryContext();
            var shelf = (from s in context.Shelves
                         where s.ShelfID == shelfID
                         select s)
                         .First();
            shelf.IsleID = isleID;
            context.SaveChanges();
        }

        public void RemoveShelf(int shelfID)
        {

            using var context = new LibraryContext();
            var shelf = (from i in context.Shelves
                        where i.ShelfID == shelfID
                        select i).FirstOrDefault();
            shelf.Deleted = true;
            context.SaveChanges();
        }
    }

        
        


    }
        

