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
    class CampgroundData
    {

        public static List<Campground> campgrounds = new List<Campground>();

        public static List<ListOfCampgrounds> listOfCampgrounds = new List<ListOfCampgrounds>();


        public static void PopulateCampgrounds()
        {
            campgrounds.Add(new Campground(42.570148, -78.051170,
                "Letchworth State Park",
                "Voted best attraction in New York state 2017 and reknown for being the grand canyon of the easy",
                "6am - 11pm",
                "https://parks.ny.gov/parks/79/details.aspx",
                "State of New York",
                "images/letchworth_state_park,png.jpg"
                ));

            campgrounds.Add(new Campground(42.967038, -78.959856,
                "Beaver Island State Park",
                "Beaver Island State Park is located at the south end of Grand Island in the upper Niagara River. Beaver Island State Park is located at the south end of Grand Island in the upper Niagara River. Beaver Island State Park is located at the south end of Grand Island in the upper Niagara River. Beaver Island State Park is located at the south end of Grand Island in the upper Niagara River. Beaver Island State Park is located at the south end of Grand Island in the upper Niagara River. ",
                "Dawn to Dusk",
                "https://parks.ny.gov/parks/56/details.aspx",
                "State of New York"
                ));

        }

        public static void PopulateList()
        {
            listOfCampgrounds.Add(new ListOfCampgrounds("New York State Parks",
                campgrounds));
        }

    }
}