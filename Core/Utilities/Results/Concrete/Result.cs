﻿using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool succes, string message):this(succes)
        {
            Message = message;
        }
        public Result(bool succes)
        {
            Succes = succes;
        }
        public bool Succes { get; }

        public string Message { get; }
    }
}
