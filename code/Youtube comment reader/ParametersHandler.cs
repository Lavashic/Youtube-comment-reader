using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Youtube_comment_reader
{
    public class Parameters
    {
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("continuation")] public string Continuation { get; set; }
        public PayloadParameters Payload { get; set; }

        public void UpdatePayload()
        {
            Payload.Continuation = Continuation;
            var url = $"https://www.youtube.com/live_chat?continuation={Continuation}";
            Payload.Context.Client.OriginalUrl = url;
            Payload.Context.Client.MainAppWebInfo.GraftUrl = url;
        }
    }

    public class ParametersHandler
    {
        public string parameters_filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\parameters.json";
        public string payload_filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\payload.json";
        public Parameters Parameters { get; set; }

        public ParametersHandler()
        {
            try
            {
                var json = JObject.Parse(File.ReadAllText(parameters_filepath));
                var parameters = json.ToObject<Parameters>();
                json = JObject.Parse(File.ReadAllText(payload_filepath));
                var payloadParameters = json.ToObject<PayloadParameters>();
                parameters.Payload = payloadParameters;
                if (parameters != null && payloadParameters != null)
                {
                    var ip = GetIPAddress("youtube.com");
                    parameters.Payload.Context.Client.RemoteHost = ip;
                    parameters.UpdatePayload();
                    Parameters = parameters;
                }
            }
            catch
            {
            }
        }
        
        public string GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var reply = ping.Send(hostName);

            if (reply.Status == IPStatus.Success)
            {
                return reply.Address.ToString();
            }
            return null;
        }
    }
}