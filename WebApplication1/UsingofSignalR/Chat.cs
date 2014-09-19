using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace UsingofSignalR
{
    [HubName("myChat")]
    public class Chat:Hub
    {
        public void send(string message)
        {
            Clients.All.addMessage(message);
           
        }
    }
}