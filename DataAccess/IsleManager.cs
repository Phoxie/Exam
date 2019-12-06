using System.Linq;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class IsleManager : IIsleManager
    {

        public void AddIsle(int isleNumber)
        {
            using var context = new LibraryContext();
            var isle = new Isle();
            isle.IsleNumber = isleNumber;
            isle.Deleted = false;
            context.Isles.Add(isle);
            context.SaveChanges();
        }

        


        public Isle GetIsleByIsleNumber(int isleNumber)
        {
            using var context = new LibraryContext();
            return (from i in context.Isles
                    where i.IsleNumber == isleNumber
                    && !i.Deleted
                    select i)
                    .Include(i => i.Shelves)
                    .FirstOrDefault();
        }

        public void RemoveIsle(int isleID)
        {

            using var context = new LibraryContext();
            var isle = (from i in context.Isles
                        where i.IsleID == isleID
                        select i).FirstOrDefault();
            isle.Deleted = true;
            context.SaveChanges();
        }

    }

    
}
