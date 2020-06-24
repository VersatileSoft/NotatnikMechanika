using NotatnikMechanika.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IAuthService
    {
        event EventHandler AuthChanged;
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
