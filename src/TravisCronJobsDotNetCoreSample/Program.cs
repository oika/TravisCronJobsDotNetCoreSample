using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TravisCronJobsDotNetCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var iftttId = Environment.GetEnvironmentVariable("IFTTT_ID");
            if (iftttId == null)
            {
                Console.WriteLine("ifttt id not defined.");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now} Start");

                var url = "https://maker.ifttt.com/trigger/ci/with/key/" + iftttId;


                var values = new Dictionary<string, string>  
                {  
                    { "value1", "testtest" },  
                };

                using (var client = new HttpClient())  
                {
                    client.PostAsync(url, new FormUrlEncodedContent(values)).Wait();
                }
            }
        }
    }
}
