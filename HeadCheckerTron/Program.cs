﻿using System;
using System.Collections.Generic;
using System.Net;

namespace HeadCheckerTron
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://med04.expertagent.co.uk/in4glestates/{7f8820d0-bb78-4105-8c70-ca5d23a41492}/{fa318b73-a054-41a6-b4ce-5c86b4e0b99a}/Photo1.jpg";


            CheckImage(url);

            Console.Read();
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
