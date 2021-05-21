using Android;
using Android.App;
using Android.Graphics;
using Android.Provider;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sailing
{
    public class DataAdapter : BaseAdapter<Data>
    {
        List<Data> items;

        Activity context;
        private global::MainActivity mainActivity;
        private List<ContactsContract.Contacts.Data> myList;

        public DataAdapter(Activity context, List<Data> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }

        public DataAdapter(global::MainActivity mainActivity, List<ContactsContract.Contacts.Data> myList)
        {
            this.mainActivity = mainActivity;
            this.myList = myList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Data this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;

            var imageBitmap = GetImageBitmapFromUrl(item.ImageURI);
            view.FindViewById<ImageView>(Resource.Id.Image)
                .SetImageBitmap(imageBitmap);
            return view;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            if (!(url == "null"))
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

            return imageBitmap;
        }
    }
}
