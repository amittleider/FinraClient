using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace FinraClient
{
    public class FinraRecordResponseParser : IFinraResponseParser<FinraRecord>
    {
        public List<FinraRecord> ParseResponse(string finraResponse)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, '|');
            CsvFieldMapping mapping = new CsvFieldMapping();
            CsvParser<FinraRecord> csvParser = new CsvParser<FinraRecord>(csvParserOptions, mapping);

            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new string[] { "\r\n" });
            var result = csvParser.ReadFromFinraString(csvReaderOptions, finraResponse, 2);

            var a = result.ToList();
            return result.Select(r => r.Result).ToList();
        }

        private class CsvFieldMapping : CsvMapping<FinraRecord>
        {
            private static readonly DtConverter dtConverter = new DtConverter();

            public CsvFieldMapping()
                : base()
            {
                MapProperty(0, x => x.Date, dtConverter);
                MapProperty(1, x => x.Symbol);
                MapProperty(2, x => x.ShortVolume);
                MapProperty(3, x => x.ShortExemptVolume);
                MapProperty(4, x => x.TotalVolume);
                MapProperty(5, x => x.Market);
            }
        }

        private class DtConverter : ITypeConverter<DateTime>
        {
            public Type TargetType => throw new NotImplementedException();
            private static readonly string validFormat = "yyyyMMdd";
            private static CultureInfo cultureInfo = new CultureInfo("en-US");

            public bool TryConvert(string value, out DateTime result)
            {
                result = DateTime.ParseExact(value, validFormat, cultureInfo);
                return true;
            }
        }
    }
}
