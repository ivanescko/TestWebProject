using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebProject.Extension.Enums;

namespace TestWebProject.Extension
{
    public static class ControllerExtensions
    {
        public static void NotifyMessage(this Controller controller, MessageType messageType, IList<string> messages, bool showAfterRedirect = true)
        {
            foreach (var message in messages)
            {
                NotifyMessage(controller, messageType, message, showAfterRedirect);
            }
        }

        public static void NotifyMessage(this Controller controller, MessageType messageType, string message, bool showAfterRedirect = true)
        {
            var messageTypeKey = messageType.ToString();
            IDictionary<string, object> dictionary = showAfterRedirect ? (IDictionary<string, object>)controller.TempData : controller.ViewData;

            if (dictionary.ContainsKey(messageTypeKey))
            {
                dictionary[messageTypeKey] = dictionary[messageTypeKey] + "<br />" + message;
            }
            else
            {
                dictionary[messageTypeKey] = message;
            }
        }
    }
}
