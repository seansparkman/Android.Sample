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

namespace App4
{
    class ContactsAdapter : BaseAdapter
    {
        Context context;
        private List<RandomUserResult> items;

        public ContactsAdapter(Context context, List<RandomUserResult> items)
        {
            this.context = context;
            this.items = items;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ContactsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ContactsAdapterViewHolder;

            if (holder == null)
            {
                holder = new ContactsAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.CellLayout, parent, false);
                view.Tag = holder;
            }


            //fill in your items
            var title = view.FindViewById<TextView>(Resource.Id.Title);
            title.Text = items[position].Name.First + " " + items[position].Name.Last;

            var subTitle = view.FindViewById<TextView>(Resource.Id.SubTitle);
            subTitle.Text = items[position].Location.City + ", " + items[position].Location.State;

            var image = view.FindViewById<ImageViewAsync>(Resource.Id.ProfileImage);
            ImageService.Instance.LoadUrl(items[position].Picture.Thumbnail).Into(image);

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

    }

    class ContactsAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}