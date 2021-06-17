using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Sailing
{
    class LocationClass
    {
        public async Task<string> GetLocation() 
        {
            //result bevat de latitude en longitude opgehaald door de gps 
            Location result = await GetCoordinates();
            

            try
            {
                var lat = result.Latitude;
                var lon = result.Longitude;

                //haalt de informatie op van de huidige locatie
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    //meerdere opties van wat je wil laten zien
                    var geocodeAddress =
                        //$"AdminArea:       {placemark.AdminArea}\n" +
                        //$"CountryCode:     {placemark.CountryCode}\n" +
                        //$"CountryName:     {placemark.CountryName}\n" +
                        //$"FeatureName:     {placemark.FeatureName}\n" +
                        $"Locality:        {placemark.Locality}\n" +
                        $"PostalCode:      {placemark.PostalCode}\n";
                    //$"SubAdminArea:    {placemark.SubAdminArea}\n" +
                    //$"SubLocality:     {placemark.SubLocality}\n" +
                    //$"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                    //$"Thoroughfare:    {placemark.Thoroughfare}\n";

                    return geocodeAddress;
                }
            }
            //catch (FeatureNotSupportedException fnsEx)
            //{
            //    // Feature not supported on device
            //}
            //catch (FeatureNotEnabledException fneEx)
            //{
            //    // Handle not enabled on device exception
            //}
            //catch (PermissionException pEx)
            //{
            //    // Handle permission exception
            //}
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                return "error";
            }

            return "error";
        }


        public async Task<Location> GetCoordinates()
        {
            var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

            return result;
        }


        public async Task<double> GetDistance()
        {
            Location current = await GetCoordinates();

            Location OtherLocation = new Location(37.783333, -122.416667);
            double Kilometers = Location.CalculateDistance(current, OtherLocation, DistanceUnits.Kilometers);

            return Kilometers;
        }
    }
}
