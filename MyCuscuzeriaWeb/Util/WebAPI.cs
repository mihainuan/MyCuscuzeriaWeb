using System.IO;
using System.Net;
using System.Text;

namespace MyCuscuzeriaWeb.Util
{
    public class WebAPI
    {
        public static string URI = "http://localhost:60806/api/users/";
        public static string TOKEN = "igH2wNmuyMO9e0Qv4FYl8StHdbQ9TFvO";

        public static string RequestGET(string metodo, string parametro)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            request.Headers.Add("Token", TOKEN);

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StringReader(response.GetResponseStream().ToString()).ReadToEnd();

            return responseString;
        }


        public static string RequestPOST(string metodo, string JsonData)
        {
            var data = Encoding.ASCII.GetBytes(JsonData);
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            request.Method = "POST";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}