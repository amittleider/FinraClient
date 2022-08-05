using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinraClient
{
    public class FinraDataFileDbStorageTool
    {
        private IFinraShortVolumeClient<string> _finraClient;
        private Stream _stream;

        public FinraDataFileDbStorageTool(
                IFinraShortVolumeClient<string> finraClient,
                Stream stream)
        {
            _finraClient = finraClient;
            _stream = stream;
        }

        public async Task StoreAllShortVolumeData()
        {
            var writer = new StreamWriter(this._stream);

            var mostRecentRecordDate = FinraClientConstants.FirstDate.AddDays(-1);

            var currentDate = mostRecentRecordDate.AddDays(1);
            var today = DateTime.Today;
            while (currentDate <= today)
            {
                try
                {
                    Console.WriteLine($"Getting Short data for {currentDate}");
                    var finraRecords = await this._finraClient.GetShortVolume(currentDate);

                    foreach (var line in finraRecords)
                    {
                        writer.WriteLine(line);
                    }
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"No Finra Short data found for {currentDate}");
                }

                currentDate = currentDate.AddDays(1);
            }

            writer.Flush();
            Console.WriteLine($"Finished");
        }
    }
}
