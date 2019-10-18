using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Maps;
using Android.Support.V4.App;
using static Android.Widget.AdapterView;
using System;
using Android.Content;

namespace homework_three
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(homework_three.Resource.Layout.activity_main);
            SupportMapFragment mapFrag = ((SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.googleMapsFragment));
            
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.googleMapsFragment, mapFrag).Commit();

            ListView campgroundListVIew = FindViewById<ListView>(Resource.Id.listOfSites);
            CampgroundData.PopulateCampgrounds();
            campgroundListVIew.Adapter = new MainCampgroundAdapater(CampgroundData.campgrounds);

            campgroundListVIew.ItemClick += OnItemClick;
        }

        public void OnItemClick(Object obj, ItemClickEventArgs args)
        {
            Intent intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("campgroundPosition", args.Position);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}