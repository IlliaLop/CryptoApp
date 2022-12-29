using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForWork
{
    internal class AllAssets
    {
        //public Quote quote { get; set; }

        public string asset_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal volume_24h { get; set; }
        public decimal change_1h { get; set; }
        public decimal change_24h { get; set; }
        public decimal change_7d { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
