using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using LumenWorks.Framework.IO.Csv;

namespace HeadCheckerTron
{
    class Program
    {

        private const string FileToUse = @"G:\My Drive\MyAdmin\MyDevProjects\HeadCheckerTron\FileInHere\TestLinksFile.csv";

        static void Main(string[] args)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(FileToUse)), true))
            {
                csvTable.Load(csvReader);
            }
            
            foreach (DataRow row in csvTable.Rows)
            {
                var path = row["path"].ToString();
                CheckImage(path);
            }
         }

        private static void CheckImage(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        Console.WriteLine("File Exists!");
                        // Image exists
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Mark image as not found!
                        Console.WriteLine("Image NOT there!");
                    }
                    else
                    {
                        Console.WriteLine($"url:{url} - response: {resp.StatusCode} - {resp.StatusDescription}");
                    }
                }
                else
                {
                    Console.WriteLine($"url:{url} - Error: {ex.Message}");
                }
            }
        }
    }
}
