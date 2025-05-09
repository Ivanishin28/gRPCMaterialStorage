﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Result
    {
        private List<string> _errors = new List<string>();

        public bool IsSuccess => _errors.Count == 0;

        public IImmutableList<string> Errors => _errors.ToImmutableList();
        public string? ErrorMessage => _errors.Count > 0 ? String.Join(" ", _errors) : null;

        private Result() { }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Failure(params string[] errors)
        {
            var result = new Result();
            result._errors.AddRange(errors);
            return result;
        }
    }
}
