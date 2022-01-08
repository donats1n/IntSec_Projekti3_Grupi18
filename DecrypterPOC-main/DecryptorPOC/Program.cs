using System;
using System.IO;
using System.Security.Cryptography;

namespace DecrypterPOC
{
    class Program
    {

        private const bool DELETE_ENCRYPTED_FILE = true; /* CAUTION */
        private const bool DECRYPT_DESKTOP = false;
        private const bool DECRYPT_DOCUMENTS = false;
        private const bool DECRYPT_PICTURES = false;
        private const bool DECRYPT_FOLDER = true;
        private const string ENCRYPTED_FILE_EXTENSION = ".jcrypt";
        private const string ENCRYPT_PASSWORD = "Password1";


        private static string DESKTOP_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static string DOCUMENTS_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string PICTURES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private static string DECRYPTION_LOG = "";
        private static string RANDOM_FOLDER = "C:/Users/Admin/Desktop/random";
        private static int decryptedFileCount = 0;

        static void Main(string[] args)
        {
           if (DECRYPT_DESKTOP)
            {
                decryptFolderContents(DESKTOP_FOLDER);
            }

            if (DECRYPT_PICTURES)
            {
                decryptFolderContents(PICTURES_FOLDER);
            }

            if (DECRYPT_DOCUMENTS)
            {
                decryptFolderContents(DOCUMENTS_FOLDER);
            }

            if (DECRYPT_FOLDER)
            {
                decryptFolderContents(RANDOM_FOLDER);
            }

            if (decryptedFileCount > 0)
            {
                dropDecryptionLog();
            }
            else
            {
                Console.Out.WriteLine("No files to encrypt.");
            } 
        }

    }
}
