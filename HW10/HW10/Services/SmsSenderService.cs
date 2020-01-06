using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HW10.Services
{
    public class SmsSenderService
    {
        public Task SendAsync(string phoneNumber)
        {
            var code = new Random().Next(1000, 9999);

            phoneNumber.TrimStart('+');
            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?" +
                $"recipient={phoneNumber}&text=Code:{code}" +
                $"&apiKey=kz9e23a329ffb61e0a90c5db047a4b0712db8a3c32384cf5786c1dfa4523fbeb16768e";

            using (var webClient = new WebClient())
            {
                webClient.DownloadString(new System.Uri(url));
            }

            return Task.CompletedTask;
        }
    }
}
