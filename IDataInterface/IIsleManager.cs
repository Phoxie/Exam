using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IIsleManager
    {
        Isle GetIsleByIsleNumber(int isleNumber);
        void AddIsle(int isleNumber);

        void RemoveIsle(int isleID);
        
    }
}
