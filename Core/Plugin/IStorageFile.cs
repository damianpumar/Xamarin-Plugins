using System;

namespace Core
{
    public interface IStorageFile
    {
        String SaveFile(Byte[] file, String pathToSave, String nameFile);

        Byte[] DownloadFile(String urlFile);
    }
}

