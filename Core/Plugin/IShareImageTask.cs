using System;

namespace Core
{
    public interface IShareImageTask
    {
        void ShareImage(String urlImage, String pathToSave, String title, params String[] comments);

        void ShareImage(String pathLocal, String title, params String[] comments);
    }
}

