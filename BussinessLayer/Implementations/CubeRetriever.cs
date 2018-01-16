using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using BussinessLayer.Models;

namespace BussinessLayer.Implementations
{
    public class CubeRetriever : ICubeQuery
    {
        

        public int executeQuery(int[] transactionValues, Cube matrix)
        {
            int sum = 0;
            List<int[]> coords = this.findCoordsWithData(transactionValues, matrix.updatedCoords);
            foreach (var item in coords)
            {
                sum += matrix.matrix[item[0], item[1], item[2]];
            }
            return sum;
        }


        private List<int[]> findCoordsWithData(int[] transactionsValues, List<int[]> updatedCoords)
        {
            int x1 = transactionsValues[0];
            int y1 = transactionsValues[1];
            int z1 = transactionsValues[2];
            int x2 = transactionsValues[3];
            int y2 = transactionsValues[4];
            int z2 = transactionsValues[5];

            List<int[]> coords = new List<int[]>();
            foreach (var item in updatedCoords)
            {
                int x = item[0];
                int y = item[1];
                int z = item[2];
                if (x >= (x1 - 1) && x< x2 && y >= (y1 - 1) && y< y2 && z >= (z1 - 1) && z< z2) {
                    coords.Add(item);
                }
            }
            return coords;
        }
    }
}
