﻿using System;
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
                    string ftpfullpath = "ftp://ftp.dlptest.com/1.jpg";
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                    ftp.Credentials = new NetworkCredential("dlpuser@dlptest.com", "SzMf7rTE4pCrf9dV286GuNe4N");

                    ftp.KeepAlive = true;
                    ftp.UseBinary = true;
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;

                    FileStream fs = File.OpenRead(@"D:\1.jpg");
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();

                    Stream ftpstream = ftp.GetRequestStream();
                    ftpstream.Write(buffer, 0, buffer.Length);
                    ftpstream.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void DownloadFileFTP()
        {
            string inputfilepath = @"C:\Temp\FileName.exe";
            string ftphost = "xxx.xx.x.xxx";
            string ftpfilepath = "/Updater/Dir1/FileName.exe";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("UserName", "P@55w0rd");
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                MessageBox.Show("Download Complete");
            }
        }
    }
}