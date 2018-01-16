using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer.Interfaces
{
    interface IDatahandler
    {
        bool InsertData(string data);

        bool readData();

        bool updateData();

        bool deleteData();
    }
}
