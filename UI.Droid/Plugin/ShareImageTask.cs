using System.Net;
using System.IO;
using System.Text;
using MvvmCross.Platform.Droid.Platform;
using Core;
using System;
using System.Linq;
using Android.Content;
using Java.Net;
using Android.Graphics;
using Java.IO;
using MvvmCross.Platform;

namespace UI.Droid
{
    public class ShareImageTask : MvxAndroidTask ,IShareImageTask
    {
        #region Members

        private const String shareImage = "Sharing";

        private const String appName = "Name Yout Application";

        private const String messageToShare = "{0} - {1} \r\n{2}";

        private readonly IStorageFile storageFile;

        #endregion

        #region Constructor

        public ShareImageTask(IStorageFile storageFile)
        {
            this.storageFile = storageFile;
        }

        #endregion

        #region Methods

        public void ShareImage(String urlImage, String pathToSave, String title, params String[] comments)
        {
            Byte[] downloadedFile = this.storageFile.DownloadFile(urlImage);

            String pathLocal = this.storageFile.SaveFile(downloadedFile, pathToSave, urlImage.Split('/').Last());

            this.ShareImage(pathLocal, title, comments);
        }

        public void ShareImage(String pathLocal, String title, params String[] comments)
        {
            if (!System.IO.File.Exists(pathLocal))
                throw new ArgumentException("File in Path local Not Exits!, please use other overload.");

            Intent sendIntent = new Intent(global::Android.Content.Intent.ActionSend);

            sendIntent.PutExtra(global::Android.Content.Intent.ExtraText, String.Format(messageToShare, appName, title, String.Join("\r\n", comments)));

            sendIntent.SetType("image/*");

            sendIntent.PutExtra(Intent.ExtraStream, Android.Net.Uri.Parse("file://" + pathLocal));

            this.StartActivity(Intent.CreateChooser(sendIntent, shareImage));
        }

        #endregion
    }

}

