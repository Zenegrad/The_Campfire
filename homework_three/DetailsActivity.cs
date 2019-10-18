using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Text.Method;
using Android.Views;
using Android.Widget;

namespace homework_three
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class DetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(homework_three.Resource.Layout.activity_detail);

            bool read_more_bool = true;
            int itemPosition = Intent.GetIntExtra("campgroundPosition", -1);
            Campground campground = CampgroundData.campgrounds[itemPosition];

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            ImageView image = FindViewById<ImageView>(Resource.Id.campgroundImage);
            TextView name = FindViewById<TextView>(Resource.Id.campgroundName);
            TextView desc = FindViewById<TextView>(Resource.Id.campgroundDescription);
            TextView hours = FindViewById<TextView>(Resource.Id.hours);
            TextView headerName = FindViewById<TextView>(Resource.Id.headerCampgroundName);
            TextView owner = FindViewById<TextView>(Resource.Id.owner);
            Button readMore = FindViewById<Button>(Resource.Id.descriptionButton);
            Button website = FindViewById<Button>(Resource.Id.website);
            ImageButton backArrow = FindViewById<ImageButton>(Resource.Id.backArrow);

            desc.MovementMethod = new ScrollingMovementMethod();
            var dp = Android.Util.ComplexUnitType.Dip;

            headerName.SetTextSize(dp, 30);
            name.SetTextSize(dp, 20);
            desc.SetTextSize(dp, 15);

            var backArrowDrawable = Drawable.CreateFromStream(this.Assets.Open("images/back_arrow.png"), null);
            var drawable = Drawable.CreateFromStream(this.Assets.Open(campground.ImageURL), null);
            var plusIcon = Drawable.CreateFromStream(this.Assets.Open("images/plus_icon.jpg"), null);

            backArrow.SetImageDrawable(backArrowDrawable);
            image.SetImageDrawable(drawable);
            fab.SetImageDrawable(plusIcon);

            name.Text = campground.Name;
            desc.Text = campground.Desc;
            hours.Text = campground.CheckInTimes;
            owner.Text = campground.Owner;
            headerName.Text = campground.Name;
            headerName.Selected = true;

            fab.Click += (sender, EventArgs) => { fabOnClick(sender, EventArgs, itemPosition); };

            void fabOnClick(object sender, EventArgs e, int position)
            {
                Intent intent = new Intent(this, typeof(AddCampground));
                intent.PutExtra("position", position);
                StartActivity(intent);
            }

            backArrow.Click += OnBackArrowPressed;

            website.Click += (sender, EventArgs) => { website_Click(sender, EventArgs, campground); };

            void website_Click(object sender, EventArgs e, Campground camp)
            {
                Intent intent = new Intent();
                intent.SetAction(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse(camp.Website));
                StartActivity(intent);
            }

            readMore.Click += (sender, EventArgs) => read_more(sender, EventArgs, desc);

            void read_more(object sender, EventArgs e, TextView textView)
            {
                if (read_more_bool)
                {
                    desc.SetHeight(ViewGroup.LayoutParams.WrapContent);
                    readMore.Text = "Less";
                    read_more_bool = false;
                }
                else
                {
                    float scale = this.Resources.DisplayMetrics.Density;
                    int pixels = (int)(100 * scale + 0.5f);

                    desc.SetHeight(pixels);
                    readMore.Text = "Read More";
                    read_more_bool = true;
                }
            }
        }
        public void OnBackArrowPressed(Object obj, EventArgs args)
        {
            Finish();
        }
    }
}