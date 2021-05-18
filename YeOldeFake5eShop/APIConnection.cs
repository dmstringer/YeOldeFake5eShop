using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace YeOldeFake5eShop
{
    public class APIConnection
    {
        static HttpClient client = new HttpClient();

        /*
        public static void KanyeQuote()
        {
            
            JArray equipList = JArray.Parse(File.ReadAllText(@"..\..\..\newEquipList.json"));
            JArray newEquipList = new JArray() { };

            foreach (JObject item in equipList) // <-- Note that here we used JObject instead of usual JProperty
            {
                if (item.SelectToken("equipment_category.index").ToString() == "mounts-and-vehicles")
                {
                    newEquipList.Add(item);

                }

                //string url = item.GetValue("url").ToString();
                //var APIResponse = client.GetStringAsync($"https://www.dnd5eapi.co{url}").Result;
                //Task.Delay(1000).Wait();
                //newEquipList.Add(APIResponse);
            }

            File.WriteAllText(@"D:\newEquipListMountsVehicles.json", newEquipList.ToString());


            var fiveERepsonse = client.GetStringAsync("https://www.dnd5eapi.co/api/equipment").Result;
            // The response has a name/value pair where the quote is called 'quote'
            var kanyeQuote = JObject.Parse(fiveERepsonse).GetValue("quote").ToString();
        }
        */
    }
}
