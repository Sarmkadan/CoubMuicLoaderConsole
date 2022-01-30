using System;
using System.ComponentModel;
using System.Net;

namespace CoubMuicLoaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DowloadFile(GetPage("https://coub.com/view/27b5ql").Split("\"audio\":{\"high\":{\"url\":\"")[1].Split("\",\"size\":")[0]);
            Console.ReadLine();

        }
        static string GetPage(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        static void DowloadFile(string url)
        {
            try
            {
                string _filename = @"C:\newproject\myfile.mp3";
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new Eventhandler(_filename);
                //webClient.DownloadProgressChanged += DownloadProgressChangedEventHandler();
                webClient.DownloadFileAsync(new Uri(url), _filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
                throw;
            }
        }

        static async void AsyncCompletedEventHandler(object sender, AsyncCompletedEventArgs e)
        {

        }




    }
}
