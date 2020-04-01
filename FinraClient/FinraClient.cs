using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinraClient
{
    public class FinraClient
    {
        public static readonly DateTime FirstDate = new DateTime(2018, 11, 5);
        private string baseUrl;
        private HttpClient client;

        public FinraClient(string baseUrl = "http://regsho.finra.org")
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public async Task<string> GetShortVolume(DateTime date)
        {
            // example URL: http://regsho.finra.org/CNMSshvol20181105.txt
            string dateString = date.ToString("yyyyMMdd");
            string fileName = $"CNMSshvol{dateString}.txt";
            string requestUrl = $"{this.baseUrl}/{fileName}";

            var response = await client.GetStringAsync(requestUrl);

            return response;
        }
    }
}
