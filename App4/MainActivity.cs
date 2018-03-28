using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using App4.Services;
using App4.Models;
using Android.Content;
using Newtonsoft.Json;

namespace App4
{
    [Activity(Label = "App4", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<string> _contacts;
        private List<RandomUserResult> _results;
        private ListView _contactListView;
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _contacts = new List<string>
            {
                "Sean",
                "Homero",
                "Andrew"
            };

            _contactListView = FindViewById<ListView>(Resource.Id.ContactList);
            _contactListView.ItemClick += _contactListView_ItemClick;
            _contactListView.ItemLongClick += _contactListView_ItemLongClick;

            var service = new RandomUserService();
            var results = await service.GetUsers(50).ConfigureAwait(false);

            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _contacts);

            _results = results.Results;
            var adapter = new ContactsAdapter(this, results.Results);

            this.RunOnUiThread(() =>
            {

                _contactListView.Adapter = adapter;
            });
        }

        private void _contactListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            // delete record or something
        }

        private void _contactListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var contact = _results[e.Position];

            var intent = new Intent(this, typeof(ContactDetailActivity));
            intent.PutExtra("Contact", JsonConvert.SerializeObject(contact));
            StartActivity(intent);
        }
    }
}

