using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeadCheckerTron
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://med04.expertagent.co.uk/in4glest ates/{7f8820d0-bb78-4105-8c70-ca5d23a41492}/{fa318b73-a054-41a6-b4ce-5c86b4e0b99a}/Photo1.jpg";
            // create the request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            // instruct the server to return headers only
            request.Method = "HEAD";
            // make the connection
            var response = request.GetResponse() as HttpWebResponse;
            // get the headers
            Console.WriteLine(response);
        }
    }
}
