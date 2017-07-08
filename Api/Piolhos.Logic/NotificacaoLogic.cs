using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace Piolhos.Logic
{
    public class NotificacaoLogic
    {
        const string fcmUrl = @"https://fcm.googleapis.com/fcm/send";
        const string serverKey = @"AIzaSyBFZusEjv7heBISksDnuPMY8Zm5h3s8ybI";
        const string senderId = @"537007328900";

        public bool Notificar(string api_key, string title, string message)
        {
            var config_api_key = ConfigurationManager.AppSettings["api_key"];

            if (api_key == config_api_key)
            {
                var msg = new
                {
                    to = "/topics/global",
                    notification = new
                    {
                        title = title,
                        body = message,
                        sound = "default",
                        icon = "smallicon"
                    },
                    data = new
                    {
                        title = message
                    },
                    priority = "high"
                };

                return Send(msg);
            }

            return false;
        }

        private static bool Send(object notification)
        {
            try
            {
                var tRequest = WebRequest.Create(fcmUrl);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                var jsonNotificationFormat = JsonConvert.SerializeObject(notification);
                var byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                var responseFromFirebaseServer = tReader.ReadToEnd();
                            }
                        }

                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
