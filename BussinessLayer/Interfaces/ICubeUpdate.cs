using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    interface ICubeUpdate
    {
         bool executeUpdate(int[] transactionValues, Cube matrix);
    }
}
