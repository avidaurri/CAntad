using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAntad.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string usuario = "Usuario";
        private const string clvemp = "0";
        private const string password = "Password";
        private const string isRemembered = "IsRemembered";

        private const string userSession = "UserSession";

        private static readonly string SettingsDefault = string.Empty;
        private static readonly bool booleanDefault = false;

        #endregion

        public static string UserSession
        {
            get
            {
                return AppSettings.GetValueOrDefault(userSession, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userSession, value);
            }
        }
        public static string Clvemp
        {
            get
            {
                return AppSettings.GetValueOrDefault(clvemp, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(clvemp, value);
            }
        }
        public static string Usuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(usuario, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(usuario, value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(password, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(password, value);
            }
        }

        public static bool IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, booleanDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }
    }
}
