using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this ile cagrialn constracter diger tek parametre alan methodu da build eder
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success=success;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public Result(string message)
        {
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
