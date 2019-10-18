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

    class MainCampgroundAdapater : BaseAdapter<Campground>
    {
        public List<Campground> campgrounds;

        public MainCampgroundAdapater(List<Campground> camp)
        {
            campgrounds = camp;
        }

        public override Campground this[int position]
        {
            get => campgrounds[position];
        }

        public override int Count
        {
            get => campgrounds.Count;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.main_activity_campground, parent, false);

            var image = view.FindViewById<ImageView>(Resource.Id.campgroundImage);
            var name = view.FindViewById<TextView>(Resource.Id.campgroundName);
            var desc = view.FindViewById<TextView>(Resource.Id.campgroundDescription);
            var distance = view.FindViewById<TextView>(Resource.Id.campgroundDistance);

            name.SetTextSize(Android.Util.ComplexUnitType.Dip, 20);
            desc.SetTextSize(Android.Util.ComplexUnitType.Dip, 15);

            var drawable = Drawable.CreateFromStream(parent.Context.Assets.Open(campgrounds[position].ImageURL), null);

            image.SetImageDrawable(drawable);

            name.Text = campgrounds[position].Name;

            //If description is too long to fit in the adpater properly then shorten it to an apprioate length
            if(campgrounds[position].Desc.Length > 86)
            {
                desc.Text = campgrounds[position].Desc.Substring(0, 85);
            }
            else
            {
                desc.Text = campgrounds[position].Desc;
            }
            distance.Text = campgrounds[position].getKmDistance(12,12);

            return view;
        }
    }
}