using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegistration
{
    public sealed class ProductManagment : ICheckout
    {
        public static List<Product> products = new List<Product>();

        private ProductManagment()
        {

            keyValuePairs.Add("A", new Dictionary<int, int> { { 1, 50 }, { 3, 130 } });
            keyValuePairs.Add("B", new Dictionary<int, int> { { 1, 30 }, { 2, 45 } });
            keyValuePairs.Add("C", new Dictionary<int, int> { { 1, 20 } });
            keyValuePairs.Add("D", new Dictionary<int, int> { { 1, 15 } });
        }


        private static ProductManagment _instance;

        public Dictionary<string, Dictionary<int, int>> keyValuePairs = new Dictionary<string, Dictionary<int, int>>();


        public static ProductManagment GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductManagment();
            }
            return _instance;
        }

        public void Scan(string item)
        {
            products.Add(new Product { ItemCode = item });

        }

        public int GetTotalPrice()
        {
            int price = 0;
            var tdata = products.GroupBy(y => y.ItemCode).Select(t =>
            new
            {
                key = t.Key,
                data = t,
                count = t.Count()

            }).ToList();


            foreach (var t in tdata)
            {
                if (keyValuePairs[t.key].ContainsKey(t.count))
                {
                    price = price + keyValuePairs[t.key][t.count];
                }
                else
                {
                    price = price + keyValuePairs[t.key][1] * t.count;
                }

            }

            var totalitem = tdata.Sum(t => t.count);

            var priceResultForBag = (int) Math.Floor((decimal)(totalitem / 5)) * 5;


            return price + priceResultForBag;


        }
    }


}
