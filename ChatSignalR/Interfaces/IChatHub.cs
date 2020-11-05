using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatSignalR.Interfaces
{
    public interface IChatHub
    {
        Task SendNotification(string type, string message);
    }
}
