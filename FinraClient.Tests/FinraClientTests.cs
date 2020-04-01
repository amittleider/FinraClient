using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FinraClient.Tests
{
    public class FinraClientTests
    {
        [Fact]
        public async Task Should_Respond_OnValidRequest()
        {
            DateTime date = new DateTime(2018, 11, 5);
            FinraClient finraClient = new FinraClient();
            string response = await finraClient.GetShortVolume(date);

            File.WriteAllText(@"C:\Users\amitt\source\FinraClient\FinraClient.Tests\finra_response.txt", response);
        }
    }
}
