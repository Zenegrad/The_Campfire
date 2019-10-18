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

namespace homework_three
{
    class ListOfCampgrounds
    {
        private string listName;
        private List<Campground> campgrounds;

        public ListOfCampgrounds(string listName, List<Campground> campgrounds)
        {
            ListName = listName;
            Campgrounds = campgrounds;
        }

        public string ListName { get => listName; set => listName = value; }
        public List<Campground> Campgrounds { get => campgrounds; set => campgrounds = value; }
    }
}