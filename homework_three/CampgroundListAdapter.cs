using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace homework_three
{
    class CampgroundListAdapter : BaseAdapter<ListOfCampgrounds>
    {

        public List<ListOfCampgrounds> list;

        public CampgroundListAdapter(List<ListOfCampgrounds> _list)
        {
            list = _list;
        }

        public override ListOfCampgrounds this[int position]
        {
            get => list[position];
        }

        public override int Count
        {
            get => list.Count;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.campground_list_adapter, parent, false);

            var image = view.FindViewById<ImageView>(Resource.Id.bookmark);
            var name = view.FindViewById<TextView>(Resource.Id.nameOfList);
            var count = view.FindViewById<TextView>(Resource.Id.countOfitems);

            var drawable = Drawable.CreateFromStream(parent.Context.Assets.Open("images/bookmark_icon.png"), null);

            image.SetImageDrawable(drawable);

            //Gets name of 
            name.Text = list[position].ListName;

            count.Text = list[position].Campgrounds.Count.ToString();

            return view;
        }

    }
}