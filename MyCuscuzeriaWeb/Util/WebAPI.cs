using System.IO;
using System.Net;
using System.Text;

namespace MyCuscuzeriaWeb.Util
{
    public class WebAPI
    {
        public static string URI = "http://localhost:60806/api/users";
        public static string TOKEN = "igH2wNmuyMO9e0Qv4FYl8StHdbQ9TFvO";

        public static string RequestGET(string route, string idx)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + "/" + route + "/" + idx);
            request.Headers.Add("Token", TOKEN);

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string responseString = reader.ReadToEnd();
                return responseString;
            }
        }


        public static string RequestPOST(string route, string JsonData)
        {
            var data = Encoding.ASCII.GetBytes(JsonData);
            var request = (HttpWebRequest)WebRequest.Create(URI + "/" + route);
            request.Method = "POST";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string responseString = reader.ReadToEnd();
                return responseString;
            }
        }

        public static string RequestPUT(string route, string idx, string JsonData)
        {
            var data = Encoding.ASCII.GetBytes(JsonData);
            var request = (HttpWebRequest)WebRequest.Create(URI + "/" + route + "/" + idx);
            request.Method = "PUT";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string responseString = reader.ReadToEnd();
                return responseString;
            }
        }
    }
}