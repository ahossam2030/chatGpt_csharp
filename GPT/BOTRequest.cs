using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GPT
{
    class BOTRequest
    {
       public   GPTResponse AskGPT(GPTRequest completionRequest)
        {
            GPTResponse completionResponse = new GPTResponse();

            using (HttpClient httpClient = new HttpClient())
            {
                using (var httpReq = new HttpRequestMessage(HttpMethod.Post, GPTSETTINGS.APIURL))
                {
                   
                    httpReq.Headers.Add("Authorization", $"Bearer {GPTSETTINGS.KEY}");
                    string requestString = JsonSerializer.Serialize(completionRequest);
                    httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage httpResponse = httpClient.SendAsync(httpReq).GetAwaiter().GetResult())
                    {

                        if (httpResponse != null)
                        {
                            if (httpResponse.IsSuccessStatusCode)//200
                            {
                                string responseString =  httpResponse.Content.ReadAsStringAsync().Result;
                                {
                                    if (!string.IsNullOrWhiteSpace(responseString))
                                    {
                                        completionResponse = JsonSerializer.Deserialize<GPTResponse>(responseString);
                                    }
                                }
                            }
                        }
                       
                    }
                }
            }
            return completionResponse;
        }
    }
}
