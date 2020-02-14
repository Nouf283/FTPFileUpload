using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPFileUpload
{
    public partial class Form1 : Form
    {

        string file = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) 
            {
                file = dlg.FileName;
                try
                {
                    //var ftpUsername = "dlpuser@dlptest.com";
                    //var ftpPassword = "SzMf7rTE4pCrf9dV286GuNe4N";
                    //string text = File.ReadAllText(file);
                    //var size = text.Length;
                    //textBox1.Text = file; // for full location
                    //byte[] bytes = Encoding.UTF8.GetBytes(file);
                    ////textBox2.Text = Path.GetFileName(Path.GetDirectoryName(file)); // for last folder name
                    //using (var client = new WebClient())
                    //{
                    //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    //    //client.UploadFile("ftp://host/path.zip", WebRequestMethods.Ftp.UploadFile, localFile);

                    //    client.UploadFile("ftp://ftp.dlptest.com/", WebRequestMethods.Ftp.UploadFile,text);
                    //}








                    // FtpWebRequest request =
                    //(FtpWebRequest)WebRequest.Create("ftp://ftp.dlptest.com/");
                    // request.Credentials = new NetworkCredential("dlpuser@dlptest.com", "SzMf7rTE4pCrf9dV286GuNe4N");
                    // request.Method = WebRequestMethods.Ftp.UploadFile;
                    // string text = File.ReadAllText(file);
                    // // using (Stream fileStream = File.OpenRead(file))
                    // //using (Stream ftpStream = request.GetRequestStream())
                    // //{
                    // //    byte[] buffer = new byte[10240];
                    // //    int read;
                    // //    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    // //    {
                    // //        ftpStream.Write(buffer, 0, read);
                    // //        Console.WriteLine("Uploaded {0} bytes", fileStream.Position);
                    // //    }
                    // //}

                    // request.Method = WebRequestMethods.Ftp.UploadFile;

                    // using (Stream fileStream = File.OpenRead(@"D:\1.jpg"))
                    // using (Stream ftpStream = request.GetRequestStream())
                    // {
                    //     fileStream.CopyTo(ftpStream);
                    // }

                    // file upload in FTP server.........................................
                    string filename = Path.GetFileName(file);
                    string ftpfullpath = "ftp://ftp.dlptest.com/test.txt";
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                    ftp.Credentials = new NetworkCredential("dlpuser@dlptest.com", "SzMf7rTE4pCrf9dV286GuNe4N");

                    ftp.KeepAlive = true;
                    ftp.UseBinary = true;
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;

                    FileStream fs = File.OpenRead(@"D:\work\test.txt");
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();

                    Stream ftpstream = ftp.GetRequestStream();
                    ftpstream.Write(buffer, 0, buffer.Length);
                    ftpstream.Close();

                  //  DownloadFileFTP();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void DownloadFileFTP()
        {
            string inputfilepath = @"D:\work\test.txt";
           // string ftphost = "xxx.xx.x.xxx";
           // string ftpfilepath = "/Updater/Dir1/FileName.exe";

            string ftpfullpath = "ftp://ftp.dlptest.com/test.txt";

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("dlpuser@dlptest.com", "SzMf7rTE4pCrf9dV286GuNe4N");
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                MessageBox.Show("Download Complete");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // DownloadFileFTP();
            //  string newtext = richTextBox1.Text;

            //  string text = File.ReadAllText(@"D:\work\test.txt");
            //  text = text.Replace(text, newtext );
            ////  text = text.Replace("some text", "new value");
            //  File.WriteAllText(@"D:\work\test.txt", text);

            DeleteFile("ok");


        }


        private string DeleteFile(string fileName)

        {
            
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.server.com/" + fileName);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.dlptest.com/test.txt");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential("dlpuser@dlptest.com", "SzMf7rTE4pCrf9dV286GuNe4N");
           // request.Credentials = new NetworkCredential("username", "password");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }
    }
}
