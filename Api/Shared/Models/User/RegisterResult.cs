using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Shared.Models.User
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
