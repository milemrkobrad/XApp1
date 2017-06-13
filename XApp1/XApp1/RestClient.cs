using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace XApp1
{
    public class RestClient
    {
        HttpClient client;
        public string EndPoint { get; set; }
        public string HttpMethod { get; set; }
        public string Response { get; set; }

        public RestClient(string endpoint)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            EndPoint = endpoint;
            HttpMethod = "GET";
            SetResponse();
        }

        public void SetResponse()
        {
            Response = MakeRequest();           
        }

        public string MakeRequest()
        {
            string _res = String.Empty;
            var uri = new Uri(string.Format(EndPoint, string.Empty));
            HttpResponseMessage response = client.GetAsync(uri).Result;
            
            if (response.IsSuccessStatusCode)
            {
                _res = response.Content.ReadAsStringAsync().Result;
            }
            return _res;

            //string strResponseValue = string.Empty;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            //request.Method = HttpMethod;

            //try
            //{
            //    var asyncResult = request.BeginGetResponse(new AsyncCallback(s =>
            //    {
            //        var response = (s.AsyncState as WebRequest).EndGetResponse(s);

            //        using (var reader = new StreamReader(response.GetResponseStream()))
            //        {
            //            strResponseValue = reader.ReadToEnd();
            //        }
            //    }), request);
            //}
            //catch { }


            //return strResponseValue;

            //not working in xamarin - GetResponse method
            /*
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = HttpMethod;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
                else
                {
                    strResponseValue = "Error code: " + response.StatusCode.ToString();
                }
            }

            return strResponseValue;*/
        }
    }
}
