using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Implementations
{
    public class InputValidator : IValidator
    {
        public bool IsValidInput(string Input)
        {
            throw new NotImplementedException();
        }

        public bool isValidQueryInput(int[] queryValues)
        {
            throw new NotImplementedException();
        }

        public bool isValidSentenceStructure(string line)
        {
            throw new NotImplementedException();
        }

        public bool isValidUpdateInput(int[] queryValues)
        {
            throw new NotImplementedException();
        }
    }
}
