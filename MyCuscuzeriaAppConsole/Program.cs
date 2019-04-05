using System;
using System.IO;
using System.Net;
using System.Text;

namespace MyCuscuzeriaAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var request = (HttpWebRequest)WebRequest.Create("http://viacep.com.br/ws/42808100/json/");
            //var request = (HttpWebRequest)WebRequest.Create("http://localhost:60122/api/webservice/getuser/56667777");
            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StringReader(response.GetResponseStream()).ReadToEnd();

            //Console.WriteLine("Resposta do método GET: " + responseString);


            var request = (HttpWebRequest)WebRequest.Create("http://localhost:60122/api/webservice/postuser");
            var postData = "{ 'variavel1':'valor1' }";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta do método POST: " + responseString);
        }
    }
}
