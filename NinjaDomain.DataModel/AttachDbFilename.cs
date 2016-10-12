using System;
using System.IO;

namespace NinjaDomain.DataModel
{
    public static class AttachDbFilename
    {
        public static void SetDataDirectory()
        {
            // Set the |DataDirectory| path used in connection strings to point to the correct directory for console app and migrations
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }
    }
}
