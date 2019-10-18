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
using static Android.Widget.AdapterView;

namespace homework_three
{
    [Activity(Label = "ListCampgroundsActivity")]
    public class ListCampgroundsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(homework_three.Resource.Layout.activity_lists_campgrounds);

            ImageButton backArrow = FindViewById<ImageButton>(Resource.Id.backArrow);
            var backArrowDrawable = Drawable.CreateFromStream(this.Assets.Open("images/back_arrow.png"), null);
            backArrow.SetImageDrawable(backArrowDrawable);
            int position = Intent.GetIntExtra("campgroundPosition", -1);

            ListView list = FindViewById<ListView>(Resource.Id.campgrounds_in_list);
            list.Adapter = new MainCampgroundAdapater(CampgroundData.listOfCampgrounds[position].Campgrounds);

            list.ItemClick += selectCampground;

            backArrow.Click += OnBackArrowPressed;
        }

        public void selectCampground(object obj, ItemClickEventArgs args)
        {
            Intent intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("campgroundPosition", args.Position);
            StartActivity(intent);
        }

        public void OnBackArrowPressed(Object obj, EventArgs args)
        {
            Finish();
        }
    }
}