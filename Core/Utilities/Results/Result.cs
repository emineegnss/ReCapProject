﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string messages) : this(success)
        {
            Messages = messages;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public string Messages { get; }

        public bool Success { get; }
    }
}
