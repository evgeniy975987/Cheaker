using Leaf.xNet;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Cheaker 
    {
        string responce = null;
        public  string Request(string proxy) {
            using (HttpRequest request = new HttpRequest()) {
                request.KeepAlive = true;
                request.ConnectTimeout = 1500;
                try {
                    request.Proxy = ProxyClient.Parse(proxy);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message + "                  "+ proxy);
                }
                if (request.Proxy == null)
                {
                    string[] protocols = new string[4];
                    protocols[0] = "http://";
                    protocols[1] = "https://";
                    protocols[2] = "socks4://";
                    protocols[3] = "socks5://";
                    for (int i = 0; i < protocols.Length; i++)
                    {
                        proxy = protocols[i] + proxy;
                        request.Proxy = ProxyClient.Parse(proxy);
                        if (responce == null)  getResponce(request);
                    }
                }
                else {
                     getResponce(request); 
                }
                return responce;
            }
        }

         void getResponce(HttpRequest request) {
                try
                {
                    responce = request.Get("http://api.ipify.org/").ToString();
            }
                catch
                {
                    responce = null;
                }
        }
    }
}
