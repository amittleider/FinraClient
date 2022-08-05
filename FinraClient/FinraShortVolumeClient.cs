using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinraClient
{
    public class FinraShortVolumeClient<T> : IFinraShortVolumeClient<T>
    {
        private readonly string baseUrl;
        private readonly HttpClient client;
        private readonly IFinraResponseParser<T> _responseParser;

        public FinraShortVolumeClient(
            IFinraResponseParser<T> responseParser,
            string baseUrl = "https://cdn.finra.org/equity/regsho/daily")
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
            this._responseParser = responseParser;
        }

        public async Task<List<T>> GetShortVolume(DateTime date)
        {
            // example URL: http://regsho.finra.org/CNMSshvol20181105.txt
            // Changed to https://cdn.finra.org/equity/regsho/daily/CNMSshvol20220804.txt

            string dateString = date.ToString("yyyyMMdd");
            string fileName = $"CNMSshvol{dateString}.txt";
            string requestUrl = $"{this.baseUrl}/{fileName}";

            var response = await client.GetStringAsync(requestUrl);

            var finraResponse = _responseParser.ParseResponse(response);

            return finraResponse;
        }
    }
}
