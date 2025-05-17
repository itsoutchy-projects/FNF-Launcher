using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FNF_Launcher
{
    /// <summary>
    /// Allows you to track progress of a download
    /// </summary>
    public class DownloadManager
    {
        /// <summary>
        /// This is from 0 - 1, multiply it by 100 to get a percentage
        /// </summary>
        public float? progress;

        public string path; // the path to the file

        public Task? downloadTask; // use a task to track progress

        public bool downloading = false;

#pragma warning disable SYSLIB0014 // Type or member is obsolete
        private WebClient client = new WebClient(); // obsolete but idk how to use httpclient, i might convert it but idk we'll see
#pragma warning restore SYSLIB0014 // Type or member is obsolete

        public event DownloadProgressChangedEventHandler? downloadProgressChanged;
        public event EventHandler? downloadCompleted;

        //public Downloading downloadingPopup;

        public DownloadManager(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Downloads the file at <paramref name="url"/> to the path
        /// <para>
        /// This does not block the calling thread, in order to call something when the
        /// download is finished, you need to use the downloadCompleted event
        /// </para>
        /// </summary>
        /// <param name="url"></param>
        public void Download(string url)
        {
            downloadTask = client.DownloadFileTaskAsync(url, path);
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        //private void startDownload()
        //{
        //    Thread thread = new Thread(() => {
        //        WebClient client = new WebClient();
        //        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        //        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
        //        client.DownloadFileAsync(new Uri("http://joshua-ferrara.com/luahelper/lua.syn"), @"C:\LUAHelper\Syntax Files\lua.syn");
        //    });
        //    thread.Start();
        //}
        //void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    downloadingPopup.BeginInvoke((MethodInvoker)delegate {
        //        double bytesIn = double.Parse(e.BytesReceived.ToString());
        //        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        //        double percentage = bytesIn / totalBytes * 100;
        //        //label2.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
        //        downloadingPopup.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        //    });
        //}
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)delegate {
            //    label2.Text = "Completed";
            //});
        }

        private void Client_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (downloadCompleted != null)
            {
                downloadCompleted(this, e);
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage / 100; // 0 - 1
            if (downloadProgressChanged != null)
            {
                downloadProgressChanged(this, e);
            }
        }
    }
}
