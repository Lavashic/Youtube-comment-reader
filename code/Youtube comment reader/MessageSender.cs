using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Youtube_comment_reader
{
    public class YoutubeMessage
    {
        public string AuthorName { get; set; }
        public string MessageText { get; set; }
    }

    public class MessageSender
    {
        private readonly Parameters _parameters;

        public MessageSender(Parameters parameters)
        {
            _parameters = parameters;
        }

        public async Task<List<YoutubeMessage>> GetMessages()
        {
            var response = await GetResponse();
            if (response != null)
            {
                UpdatePayload(response);
                var messages = response.ContinuationContents?.LiveChatContinuation?.Actions?
                    .Where(i => !string.IsNullOrWhiteSpace(i.AddChatItemAction?.Item?.LiveChatTextMessageRenderer?.AuthorName?.SimpleText)
                    && i.AddChatItemAction?.Item?.LiveChatTextMessageRenderer?.Message?.Runs != null && 
                    i.AddChatItemAction?.Item?.LiveChatTextMessageRenderer?.Message?.Runs.Count > 0)
                    .Select(i =>
                    {
                        var message = new YoutubeMessage();
                        message.MessageText = i.AddChatItemAction.Item.LiveChatTextMessageRenderer.Message.Runs.FirstOrDefault()?.Text;
                        message.AuthorName = i.AddChatItemAction.Item.LiveChatTextMessageRenderer.AuthorName.SimpleText;
                        return message;
                    }).ToList() ?? new List<YoutubeMessage>();
                return messages;
            }

            return new List<YoutubeMessage>();
        }

        private void UpdatePayload(YoutubeResponse response)
        {
            var continuations = response?.ContinuationContents?.LiveChatContinuation?.Continuations;
            if (continuations == null || continuations.Count == 0 || continuations[0] == null ||
                (string.IsNullOrWhiteSpace(continuations[0].TimedContinuationData?.Continuation) &&
                 string.IsNullOrWhiteSpace(continuations[0].ReloadContinuationData?.Continuation)))
            {
                return;
            }

            var continuation = continuations[0].TimedContinuationData?.Continuation ??
                               continuations[0].ReloadContinuationData?.Continuation;
            _parameters.Continuation = continuation;
            _parameters.UpdatePayload();
            
        }

        private async Task<YoutubeResponse> GetResponse()
        {
            var response = await SendRequest($"https://www.youtube.com/youtubei/v1/live_chat/get_live_chat?key={_parameters.Key}");
            if (string.IsNullOrWhiteSpace(response))
            {
                return new YoutubeResponse();
            }

            var parsedResponse = JsonConvert.DeserializeObject<YoutubeResponse>(response);
            return parsedResponse;
        }

        private async Task<string> SendRequest(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                await using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
                {
                    string json = JsonConvert.SerializeObject(_parameters.Payload, Formatting.Indented);
                    await streamWriter.WriteAsync(json);
                }

                var response = (HttpWebResponse)(await request.GetResponseAsync());

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var encoding = Encoding.UTF8;
                    using var reader =
                        new StreamReader(
                            response.GetResponseStream() ?? throw new InvalidOperationException(), encoding);
                    var responseText = await reader.ReadToEndAsync();
                    return responseText;
                }
            }

            catch
            {
                return null;
            }

            return null;
        }
    }
}