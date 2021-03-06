using System;
using Core;
using System.Net;
using System.IO;

namespace UI.Droid
{
    public class StorageFile : IStorageFile
    {
        private const String appName = "Path Your Application";
        
        public String SaveFile(Byte[] file, String pathToSave, String nameFile)
        {
            String pathDirectoryApplication = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, appName);

            String pathDirectoryImagenes = System.IO.Path.Combine(pathDirectoryApplication, pathToSave);

            String pathFile = System.IO.Path.Combine(pathDirectoryImagenes, nameFile);

            if (!Directory.Exists(pathDirectoryApplication))
                Directory.CreateDirectory(pathDirectoryApplication);

            if (!Directory.Exists(pathDirectoryImagenes))
                Directory.CreateDirectory(pathDirectoryImagenes);

            if (!File.Exists(pathFile))
                File.WriteAllBytes(pathFile, file);

            return pathFile;
        }

        public Byte[] DownloadFile(String urlFile)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadData(urlFile);
            }
        }
    }
}
