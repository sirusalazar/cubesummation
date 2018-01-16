using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class Cube
    {
        public int[,,] matrix { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public List<int[]> updatedCoords { get; set; }

        public void  Build()
        {
            updatedCoords = new List<int[]>();
            matrix = new int[X, Y, Z];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    for (int k = 0; k < Z; k++)
                    {
                        matrix[i, j, k] = 0;
                    }
                }
            }
        }

        public void updateValue(int x, int y, int z, int W)
        {
            int[] values=new int[3];
            values[0] = x;
            values[1] = y;
            values[2] = z;
            matrix[x, y, z] = W;
            updatedCoords.Add(values);
        }
    }
}
