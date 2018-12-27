using System;
using System.Collections.Generic;
using System.Text;

namespace SertzHir.Core
{
    public class Result
    {
        public bool Successful { get; set; }
        public string Value { get; set; }

        public object ObjectValue { get; set; }

        public string Message { get; set; }

    }
}
