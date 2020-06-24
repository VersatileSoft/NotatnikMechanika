using NotatnikMechanika.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Client.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public Task ShowMessageDialog(string message)
        {
            return Task.CompletedTask;
        }
    }
}
