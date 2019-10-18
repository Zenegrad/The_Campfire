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
using static Android.Widget.AdapterView;

namespace homework_three
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class AddCampground : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(homework_three.Resource.Layout.activity_add_campground);

            ListView list = FindViewById<ListView>(Resource.Id.list_of_campgrounds);
            CampgroundData.PopulateList();
            list.Adapter = new CampgroundListAdapter(CampgroundData.listOfCampgrounds);

            ImageButton backArrow = FindViewById<ImageButton>(Resource.Id.backArrow);

            backArrow.Click += OnBackArrowPressed;

            list.ItemClick += OnItemClick;

        }

        public void OnItemClick(Object obj, ItemClickEventArgs args)
        {
            Intent intent = new Intent(this, typeof(ListCampgroundsActivity));
            intent.PutExtra("campgroundPosition", args.Position);
            StartActivity(intent);
        }

        public void OnBackArrowPressed(Object obj, EventArgs args)
        {
            Finish();
        }
    }
}