using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AirMouse
{
    public static class NetUtils
    {
        public static string DownloadedTargetTempPath;
        public const string ServerCheckFileAddress = "http://androidairmouse.com/downloads/latestserverversion";
        public const string ServerApplicationAddress = "http://androidairmouse.com/downloads/download.php";
        public static event EventHandler<DownloadingProgressEventArgs> OnProgressChanged;
        public static event EventHandler OnDownloadCompleted;
        public static event EventHandler<DownloadingErrorEventArgs> OnError;

        static WebClient webClient;
        private static Stopwatch sw = new Stopwatch();

        public static void Cancel()
        {
            if (webClient != null && webClient.IsBusy)
                webClient.CancelAsync();
        }

        public static void DownloadLatestVersion()
        {
            DownloadedTargetTempPath = Path.Combine(Path.GetTempPath(), "AirMouseTempUpdate.exe");
            DownloadFile(ServerApplicationAddress, DownloadedTargetTempPath);
        }

        public static void DownloadFile(string urlAddress, string filePath)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += Completed;
                webClient.DownloadProgressChanged += ProgressChanged;

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, filePath);
                }
                catch (Exception ex)
                {
                    if (OnError != null)
                    {
                        OnError(null, new DownloadingErrorEventArgs { Error = ex.Message });
                    }
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (OnProgressChanged != null)
            {
                var args = new DownloadingProgressEventArgs();
                args.CurrentSpeed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
                args.CurrentPercentage = e.ProgressPercentage;
                args.TotalDownloaded = (e.BytesReceived / 1024d).ToString("0.00");
                args.TotalSize = (e.TotalBytesToReceive / 1024d).ToString("0.00");
                args.Remaining = ((e.TotalBytesToReceive - e.BytesReceived) / 1024d).ToString("0.00");
                OnProgressChanged(null, args);
            }
        }

        private static void Completed(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            sw.Reset();

            if (e.Cancelled == true)
            {
                if (OnError != null)
                {
                    OnError(null, new DownloadingErrorEventArgs { Cancelled = true });
                }
            }
            else
            {
                if (OnDownloadCompleted != null)
                {
                    OnDownloadCompleted(null, null);
                }
            }
            if (webClient != null)
            {
                webClient.Dispose();
            }
        }


        public static uint GetLatestVersionPublished()
        {
            uint latestVersion = 0;

            using (WebClient client = new WebClient())
            {
                try
                {
                    Stream stream = client.OpenRead(ServerCheckFileAddress);
                    StreamReader reader = new StreamReader(stream);
                    String content = reader.ReadToEnd();

                    if (content != null)
                    {
                        var trimed = content.Replace(".", "");

                        var toFill = 4 - trimed.Length;

                        for (int i = 0; i < toFill; i++)
                        {
                            trimed += "0";
                        }

                        try
                        {
                            latestVersion = Convert.ToUInt32(trimed);
                        }
                        catch
                        {
                            latestVersion = 0;
                        }
                    }
                }
                catch
                {
                    latestVersion = 0;
                }
            }

            return latestVersion;
        }
    }


    public class DownloadingProgressEventArgs : EventArgs
    {
        public string CurrentSpeed;
        public int CurrentPercentage;
        public string TotalSize;
        public string TotalDownloaded;
        public string Remaining;
    }
    public class DownloadingErrorEventArgs : EventArgs
    {
        public bool Cancelled;
        public string Error;
    }
}
