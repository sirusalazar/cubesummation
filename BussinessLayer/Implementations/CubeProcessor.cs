using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Implementations
{
    public class CubeProcessor:ICubeProcessor
    {
        Cube _cube;
        int transactionsQuantity;
        int queries;
        IValidator _validator;
        ICubeUpdate _updater;
        ICubeQuery _retriever;

        CubeProcessor(IValidator validator, ICubeUpdate updater, ICubeQuery retriever)
        {
            this._validator = validator;
            this._updater = updater;
            this._retriever = retriever;
        }

        public int[] processInput(string input)
        {
            try
            {
                if (this._validator.IsValidInput(input))
                {
                    string[] inputAsArray = input.Split('\n');
                    this.buildCube(inputAsArray[1]);
                    this.gettransactionsQuantity(inputAsArray[1]);
                    this.getQueriesCuantity(inputAsArray[0]);
                    return this.executeTransations(input);
                }
            }catch(Exception e)
            {

            }
            return new int[0];
        }

        private void gettransactionsQuantity(string line)
        {
            string[] lineValues = line.Split(' ');
            this.transactionsQuantity = int.Parse(lineValues[1]);
        }

        private void buildCube(string input)
        {
            string[] lineValues = input.Split(' ');
            int matrixDimension = int.Parse(lineValues[0]);
            this._cube = new Cube();
            this._cube.X = matrixDimension;
            this._cube.Y = matrixDimension;
            this._cube.Z = matrixDimension;
            this._cube.Build();
        }

        private void getQueriesCuantity(string input)
        {
            this.queries = int.Parse(input);
        }

        
       public int[] executeTransations(string input)
        {
            List<int> results = new List<int>();
            string[] linesAsArray = input.Split('\n');
            int inputPointer = 2;
            int iterator = 0;
            while (iterator < this.transactionsQuantity)
            {
                int transactionResult = this.selectTransaction(linesAsArray[inputPointer]);
                if(transactionResult>-1)
                {
                    results.Add(transactionResult);
                }
                iterator++;
                inputPointer++;
            }
            return results.ToArray();
        }

        private int executeQuery(string readedLine)
        {
            if (this._validator.isValidSentenceStructure(readedLine))
            {
                return this.selectTransaction(readedLine);
            }
            return -1;
        }

        private int selectTransaction(string line)
        {
            string[] lineAsArray = line.Split(' ');
            string[] transactionValues = String.Join(",", lineAsArray, 1, lineAsArray.Length - 1).Split(',');
            int[] intTransactionsValues = Array.ConvertAll<string, int>(transactionValues, int.Parse);
            int output = -1;
            switch (lineAsArray[0].ToUpper())
            {
                case "UPDATE":
                    if (this._validator.isValidUpdateInput(intTransactionsValues))
                    {
                        this._updater.executeUpdate(intTransactionsValues, this._cube);
                        output = -2;
                    }
                    break;
                case "QUERY":
                    if(this._validator.isValidQueryInput(intTransactionsValues))
                    {
                        output = this._retriever.executeQuery(intTransactionsValues,this._cube);
                    }
                    break;
            }
            return output;
        }
    }
}