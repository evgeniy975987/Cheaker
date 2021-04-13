using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class Proxy
    {
        String proxy;
        string responceRezult;

        public Proxy(string proxy, string status) {
            this.proxy = proxy;
            this.responceRezult = status;
        }

        public string getProxy() {
            return "Прокси " + proxy + ";  ответ при проверке " + responceRezult;
        }
    }
}
