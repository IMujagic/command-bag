using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Common
{
    public class Result
    {
        private bool _isSuccess;
        private string _message;

        private Result(bool isSuccess, string message = null)
        {
            _isSuccess = isSuccess;
            _message = message;
        }

        public static Result Ok()
        {
            return new Result(true);
        }

        public static Result Error(string message)
        {
            return new Result(false, message);
        }
    }
}
