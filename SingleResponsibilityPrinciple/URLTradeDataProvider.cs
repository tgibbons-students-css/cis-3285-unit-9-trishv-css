using System.Collections.Generic;
using System.IO;

using SingleResponsibilityPrinciple.Contracts;
using System.Net;

namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        private string url;

    }
}
