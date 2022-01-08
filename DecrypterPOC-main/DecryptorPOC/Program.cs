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
        private static void dropDecryptionLog()
        {
            StreamWriter ransomWriter = new StreamWriter(DESKTOP_FOLDER + @"\___DECRYPTION_LOG.txt");
            ransomWriter.WriteLine(decryptedFileCount + " files have been decrypted." +
                "\n----------------------------------------\n" +
                DECRYPTION_LOG);
            ransomWriter.Close();
        }

        private static bool fileIsEncrypted(string inputFile)
        {
            if (inputFile.Contains(ENCRYPTED_FILE_EXTENSION))
                if (inputFile.Substring(inputFile.Length - ENCRYPTED_FILE_EXTENSION.Length, ENCRYPTED_FILE_EXTENSION.Length) == ENCRYPTED_FILE_EXTENSION)
                    return true;
            return false; 
        }

        static void decryptFolderContents(string sDir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(sDir))
                {
                    if (fileIsEncrypted(file))
                    {
                        FileDecrypt(file, file.Substring(0, file.Length - ENCRYPTED_FILE_EXTENSION.Length), ENCRYPT_PASSWORD);
                    }
                }

                foreach (string directory in Directory.GetDirectories(sDir))
                {
                    decryptFolderContents(directory);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
