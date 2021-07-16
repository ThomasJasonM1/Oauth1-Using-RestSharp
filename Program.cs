using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Oauth1_Test
{
    class Program
    {
        // Fill in these 4 variables
        // The consumerKey, consumerSecret and tokenValue can be found in the welcome email your received when you gained access to use our API
        // The conversationId can come from the excel file you received earlier today
        private static string conversationId = "";
        private static string consumerKey = "";
        private static string consumerSecret = "";
        private static string tokenValue = "";


        // You don't need to modify anything below this line
        private static string tokenSecret = ""; // Leave this an empty string
        // This URL can be modified based on the endpoint you want to call
        private static string baseUrl = "https://staging-rest.call-em-all.com/v1/{path}";

        static void Main(string[] args)
        {

            try
            {
                var client = new RestClient(baseUrl);
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, tokenValue, tokenSecret);

                var request = new RestRequest(Method.GET)
                    .AddUrlSegment("path", "conversations/" + conversationId + "/textmessages");

                var response = client.Execute(request);
                Console.WriteLine(@"Response " + response.Content);
                Console.ReadLine();


            }
            catch (Exception e)
            {
                Console.WriteLine(@"Error: " + e);
                Console.ReadLine();
            }
        }
    }
}
