using CsQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebrequestHw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listText = new List<string>();

            string urlAddress = "https://github.com/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                CQ domObjects = data;

                CQ doms = domObjects["*"];

                foreach (var i in doms.ToList())
                {
                    listText.Add(i.InnerText);
                }

                foreach (var i in listText)
                {
                    Console.WriteLine(i);
                }
                

                response.Close();
                readStream.Close();
            }
        }
    }
}