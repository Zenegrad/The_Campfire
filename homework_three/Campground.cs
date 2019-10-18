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
    public class Campground
    {

        double latitude;
        double longitude;
        string name;
        string desc;
        string checkInTimes;
        string website;
        string owner;
        string imageURL;

        public Campground()
        {

        }

        public Campground(double latitude, double longitude, string name, string desc, string checkInTimes, string website, string owner)
        {
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Desc = desc;
            CheckInTimes = checkInTimes;
            Website = website;
            Owner = owner;
            ImageURL = "images/image_not_found.png";
        }

        public Campground(double latitude, double longitude, string name, string desc, string checkInTimes, string website, string owner, string imageURL)
        {
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Desc = desc;
            CheckInTimes = checkInTimes;
            Website = website;
            Owner = owner;
            ImageURL = imageURL;
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public double calculateDistance(double targetLat, double targetLong)
        {

            var radius = 6371e3; // metres
            var φ1 = ConvertToRadians(latitude);
            var φ2 = ConvertToRadians(targetLat);
            var Δφ = ConvertToRadians(latitude - targetLat);
            var Δλ = ConvertToRadians(targetLong - longitude);

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = (radius * c);

            return distance;
        }

        public string getKmDistance(double targetLat, double targetLong)
        {
            return (Math.Round(calculateDistance(targetLat, targetLong) / 1000, 1)) + " km";
        }

        public string getMileDistance(double targetLat, double targetLong)
        {
            return (Math.Round((calculateDistance(targetLat, targetLong) * 0.621371) / 1000, 1)) + " mi";
        }

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public string CheckInTimes { get => checkInTimes; set => checkInTimes = value; }
        public string Website { get => website; set => website = value; }
        public string Owner { get => owner; set => owner = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
    }
}