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
            IFinraShortVolumeClient<FinraRecord> finraClient = new FinraShortVolumeClient<FinraRecord>(new FinraRecordResponseParser());
            var response = await finraClient.GetShortVolume(date);

            response.Should().NotBeNull();
        }
    }
}
