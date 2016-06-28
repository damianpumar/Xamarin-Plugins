using System;
using Core;
using System.Net;
using System.IO;

namespace UI.Droid
{
    public class StorageFile : IStorageFile
    {
        #region Methods

        public String SaveFile(Byte[] file, String pathToSave, String nameFile)
        {
            //Check directory levels, Change it!.
            String pathDirectoryApplication = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Path Your Application");

            String pathDirectoryImagenes = System.IO.Path.Combine(pathDirectoryApplication, pathToSave);

            String pathFile = System.IO.Path.Combine(pathDirectoryImagenes, nameFile);

            if (!Directory.Exists(pathDirectoryApplication))
                Directory.CreateDirectory(pathDirectoryApplication);

            if (!Directory.Exists(pathDirectoryImagenes))
                Directory.CreateDirectory(pathDirectoryImagenes);

            if (File.Exists(pathFile))
                return pathFile;

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

        #endregion
    }
}