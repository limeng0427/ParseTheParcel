using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Trademe.ParseTheParcel.Utilities
{
    public static class StringUtility
    {

    }

    public static class NumberUtility
    {

    }

    public static class DateTimeUtility
    {

    }

    public static class JsonUtility
    {

    }
    public static class Utility
    {
        public static class ConfigurationManagerHelper
        {
            public static bool Exists()
            {
                return Exists(System.Reflection.Assembly.GetEntryAssembly());
            }

            public static bool Exists(Assembly assembly)
            {
                return System.IO.File.Exists(assembly.Location + ".config");
            }
        }

    }
}
