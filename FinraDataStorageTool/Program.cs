using FinraClient;
using System.IO;
using System.Threading.Tasks;

namespace FinraDataStorageTool
{
    public class Program
    {
        public static async Task Main()
        {
            var fileStream = File.OpenWrite("finraDb.csv");
            var finraClient = new FinraShortVolumeClient<string>(new HeaderFooterRemoverResponseParser());

            FinraDataFileDbStorageTool tool = new FinraDataFileDbStorageTool(finraClient, fileStream);
            await tool.StoreAllShortVolumeData();
        }
    }
}
