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
            

            try
            {
                //result bevat de latitude en longitude opgehaald door de gps 
                Location result = await GetCoordinates();
                //de Location in activityitem is aangepast naar Locations om verwaring met de gps location tegen te gaan

                var lat = result.Latitude;
                var lon = result.Longitude;

                //haalt de informatie op van de huidige locatie
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    //meerdere opties van wat je wil laten zien
                    //var geocodeAddress =
                        //$"AdminArea:       {placemark.AdminArea}\n" +
                        //$"CountryCode:     {placemark.CountryCode}\n" +
                        //$"CountryName:     {placemark.CountryName}\n" +
                        //$"FeatureName:     {placemark.FeatureName}\n" +
                        //$"Locality:        {placemark.Locality}\n" +
                        //$"PostalCode:      {placemark.PostalCode}\n" +
                        //$"SubAdminArea:    {placemark.SubAdminArea}\n" +
                        //$"SubLocality:     {placemark.SubLocality}\n" +
                        //$"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                        //$"Thoroughfare:    {placemark.Thoroughfare}\n";

                    var geocodeAddress = placemark.Locality;

                    return geocodeAddress;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                return "Not Supported error";
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                return "Please enable GPS";
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return "Permission error";
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                return "error";
            }

            return "error";
        }


        public async Task<Location> GetCoordinates()
        {
            //gebruikt de gps om coordinaten op te halen, GeolocationAccuracy is natuurlijk hoe accuraat de coordinaten zijn, en de timespan is hoeveel tijd hij mag gebruiken
            var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

            return result;
        }

        /// <summary>
        /// method om afstand tussen 2 locaties te berekenen
        /// </summary>
        /// <returns></returns>
        public async Task<double> GetDistance()
        {
            //haalt de huidige locatie op
            Location current = await GetCoordinates();
            //otherlocation is nu een voorbeeld, je kan een locatie of coordinaten meegeven en dan wordt de afstand in kilometer berekend
            Location OtherLocation = new Location(37.783333, -122.416667);
            double Kilometers = Location.CalculateDistance(current, OtherLocation, DistanceUnits.Kilometers);

            return Kilometers;
        }
    }
}
