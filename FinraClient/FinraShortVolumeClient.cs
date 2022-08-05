using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinraClient
{
    public class FinraShortVolumeClient : IFinraShortVolumeClient
    {
        public static readonly DateTime FirstDate = new DateTime(2018, 11, 5);
        private string baseUrl;
        private HttpClient client;

        public FinraShortVolumeClient(string baseUrl = "https://cdn.finra.org/equity/regsho/daily")
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public async Task<List<FinraRecord>> GetShortVolume(DateTime date)
        {
            // example URL: http://regsho.finra.org/CNMSshvol20181105.txt
            // Changed to https://cdn.finra.org/equity/regsho/daily/CNMSshvol20220804.txt

            string dateString = date.ToString("yyyyMMdd");
            string fileName = $"CNMSshvol{dateString}.txt";
            string requestUrl = $"{this.baseUrl}/{fileName}";

            var response = await client.GetStringAsync(requestUrl);
            var finraResponse = FinraResponseParser.ParseResponse(response);

            return finraResponse;
        }
    }
}
