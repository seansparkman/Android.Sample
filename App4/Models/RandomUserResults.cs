using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace App4.Models
{
    public class RandomUserResults
    {
        [JsonProperty("results")]
        public List<RandomUserResult> Results { get; set; }
        [JsonProperty("info")]
        public RandomUserInfo Info { get; set; }
    }

}