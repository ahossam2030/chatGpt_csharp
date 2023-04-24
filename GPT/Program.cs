using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GPT
{
    class Program
    {
         static  void Main(string[] args)
        {
            BOTRequest request = new BOTRequest();
            GPTRequest RequestInfo = new GPTRequest
            {
                MaxTokens = 120,
                Model = "text-davinci-003",

            };
           
            while (true)
            {
                Console.Write("You :");
                var Input= Console.ReadLine();
                RequestInfo.Prompt = Input;
                var GptModelresponse =request.AskGPT(RequestInfo);
                if(GptModelresponse!=null)
                {
                    Console.WriteLine("GPT :" + GptModelresponse.Choices[0]?.Text ?? "No defined");

                }
                
                


             }
        }
       
    }
}
