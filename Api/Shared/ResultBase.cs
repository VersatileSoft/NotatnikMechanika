using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared
{
    public abstract class ResultBase
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
