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
using App4.Models;
using FFImageLoading;
using FFImageLoading.Views;
using Newtonsoft.Json;

namespace App4
{
    [Activity(Label = "ContactDetail")]
    public class ContactDetailActivity : Activity
    {
        RandomUserResult result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ContactDetail);

            var emailButton = FindViewById<Button>(Resource.Id.EmailButton);
            var phoneButton = FindViewById<Button>(Resource.Id.CallButton);
            var image = FindViewById<ImageViewAsync>(Resource.Id.ProfileImage);

            var json = Intent.GetStringExtra("Contact");
            result = JsonConvert.DeserializeObject<RandomUserResult>(json);
            ImageService.Instance.LoadUrl(result.Picture.Medium).Into(image);
            emailButton.Click += (object sender, EventArgs e) =>
            {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail,
                    new string[] { result.Email });
                email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Contact");

                email.SetType("message/rfc822");

                StartActivity(email);
            };


         }
    }
}