// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Interest.Helpers
{

    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;//breaks here
            }
        }



        public static string Username
        {

            get
            {
                return AppSettings.GetValueOrDefault<string>("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Username", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }


        //public static DateTime AccessTokenExpirationDate
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault<DateTime>("AccessTokenExpirationDate", DateTime.UtcNow);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue<DateTime>("AccessTokenExpirationDate", value);
        //    }

        //}
    }
}