using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace YeOldeFake5eShop.Helpers
{
    public class APIConnection
    {
        //My original idea was to use the API I found below to get all my page data,
        //but because of the limited way that API sends back large lists, I decided to 
        //extract all his data and just use that as modified local JSON files.
        //Didn't feel like turning it into a database :)

        //static HttpClient client = new HttpClient();

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
            
        }
        */
    }
}
