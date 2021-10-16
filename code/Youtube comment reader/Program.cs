using System;
using System.Threading;
using System.Threading.Tasks;

namespace Youtube_comment_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = MainAsync(args);
            t.Wait();
        }

        static async Task MainAsync(string[] args)
        {
            try
            {
                var parametersHandler = new ParametersHandler();
                var parameters = parametersHandler.Parameters;
                if (parameters == null)
                {
                    return;
                }
                var sender = new MessageSender(parameters);
                while (true)
                {
                    var messages = await sender.GetMessages();
                    foreach (var youtubeMessage in messages)
                    {
                        Console.WriteLine($"[{youtubeMessage.AuthorName}]: {youtubeMessage.MessageText}");
                    }
                    Thread.Sleep(1000);
                }

            }
            catch
            {
            }
        }
    }
}