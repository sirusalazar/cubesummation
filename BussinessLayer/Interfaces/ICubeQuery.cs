using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ICubeQuery
    {
        int executeQuery(int[] transactionValues, Cube matrix);
    }
}
