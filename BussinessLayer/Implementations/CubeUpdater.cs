using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using BussinessLayer.Models;

namespace BussinessLayer.Implementations
{
    class CubeUpdater : ICubeUpdate
    {
        public bool executeUpdate(int[] transactionValues, Cube matrix)
        {
            try
            {
                int x = transactionValues[0];
                int y = transactionValues[1];
                int z = transactionValues[2];
                int W = transactionValues[3];
                matrix.updateValue(x, y, z, W);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
