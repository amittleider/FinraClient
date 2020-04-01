using System;
using System.Collections.Generic;
using System.Text;

namespace FinraClient
{
    public class FinraRecord
    {
        // Date|Symbol|ShortVolume|ShortExemptVolume|TotalVolume

        public DateTime Date
        {
            get;
            set;
        }

        public string Symbol
        {
            get;
            set;
        }

        public int ShortVolume
        {
            get;
            set;
        }

        public int ShortExemptVolume
        {
            get;
            set;
        }

        public int TotalVolume
        {
            get;
            set;
        }

        public string Market
        {
            get;
            set;
        }

        public FinraRecord()
        {
        }
    }
}
