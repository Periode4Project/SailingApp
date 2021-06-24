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
        /// <summary>
        /// pakt de locatie doormiddel van het aanroepen van de getcoordinates method
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetLocation() 
        {

            try
            {
                //result bevat de latitude en longitude opgehaald door de gps 
                Location result = await GetCoordinates();

                var lat = result.Latitude;
                var lon = result.Longitude;

                //haalt de informatie op van de huidige locatie doormiddel van coordinaten via xamarin essentials
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    //pakt de locality(plaats/ligging) van de locatie
                    var geocodeAddress = placemark.Locality;
                    //returnt de huidige locatie
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

        /// <summary>
        /// zelfde als de vorige method alleen geef je de coordinaten al mee
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task<string> GetLocationName(Location result)
        {
            try
            {
                //pak de latitude en longitude van de meegegeven locatie(coordinaten)
                var lat = result.Latitude;
                var lon = result.Longitude;

                //haalt de informatie op van de huidige locatie
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {

                    //pakt de locality(plaats/ligging) van de locatie
                    var geocodeAddress = placemark.Locality;
                    //returnt de huidige locatie
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
        public double GetDistance(Location other)
        {
            //haalt de huidige locatie op
            //Location current = await GetCoordinates();
            Location current = Coordinates.currentLocation;

            
            //otherlocation is nu een voorbeeld, je kan een locatie of coordinaten meegeven en dan wordt de afstand in kilometer berekend
            //Location OtherLocation = new Location(37.783333, -122.416667);
            double Kilometers = Location.CalculateDistance(current, other, DistanceUnits.Kilometers);

            return Kilometers;
        }

        /// <summary>
        /// method om een address om te zetten in coordinaten
        /// </summary>
        /// <param name="address">een address waar de coordinaten van worden opgehaald</param>
        /// <returns></returns>
        public async Task<Location> AddressToCoordinates(string address)
        {
            try
            { 
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    return location;
                }

                Location error = new Location(0.000, 0.000);
                return error;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Location error = new Location(0.000, 0.000);
                return error;
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                Location error = new Location(0.000, 0.000);
                return error;
            }
        }
    }
}
