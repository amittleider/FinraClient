using FluentAssertions;
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
            FinraShortVolumeClient finraClient = new FinraShortVolumeClient();
            var response = await finraClient.GetShortVolume(date);

            response.Should().NotBeNull();
        }
    }
}
