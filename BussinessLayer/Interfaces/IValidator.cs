using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    interface IValidator
    {
        bool IsValidInput(string Input);

        bool isValidQueryInput(int[] queryValues);

        bool isValidUpdateInput(int[] queryValues);

        bool isValidSentenceStructure(string line);
    }
}
