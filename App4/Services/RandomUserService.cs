using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App4.Models;
using Newtonsoft.Json;

namespace App4.Services
{
    public class RandomUserService
    {
        private HttpClient client;

        public RandomUserService()
        {
            client = new HttpClient();
        }
        public async Task<RandomUserResults> GetUsers(int count)
        {
            try
            {
                var response = await client.GetAsync($"https://randomuser.me/api?results={count}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseText = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<RandomUserResults>(responseText);
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }

            throw new Exception("Failed!!!");
        }
    }
}