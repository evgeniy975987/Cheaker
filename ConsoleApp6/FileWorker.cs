using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
     class FileWorker
    {
        static string _pathFileProxie;
        static string _pathSaveFile;
        string[] _proxyArray;
        List <String> _workingProxies = new List<String>();
        public FileWorker(string pathFileProxies, string pathSaveFile, int threadCount) {
            _pathFileProxie = pathFileProxies;
            _proxyArray = File.ReadAllLines(_pathFileProxie);
            _pathSaveFile = pathSaveFile;

            int endCycle = _proxyArray.Length;
            int startCycle = endCycle - (endCycle / threadCount);
            int i = 0;
            
            for (; i <= threadCount; i++) {
                Thread thread = new Thread(() => { Read(startCycle , endCycle ); });
                thread.Start();
                endCycle = endCycle - (endCycle / threadCount);
                startCycle = endCycle - (endCycle / threadCount);
            }

            if (endCycle > 0) {
                Thread thread = new Thread(() => { Read(0, endCycle); });
                thread.Start();
            }
        }

        public void Read(int startСycle, int endCycle )
        {
            for (int i = startСycle ; i <= endCycle; i++)
            {
                Cheaker cheaker = new Cheaker();
                string responce = cheaker.Request(_proxyArray[i]);
                if (responce != null) {
                    Proxy proxy = new Proxy(_proxyArray[i], responce);
                    _workingProxies.Add(proxy.getProxy());
                    Console.WriteLine(proxy.getProxy());
                }
                else {
                    Console.WriteLine(_proxyArray[i] + " не актуален ");
                }
            }
            if (startСycle == 0) Write();
        }

        public void Write()
        {
            File.WriteAllLines(_pathSaveFile, _workingProxies.ToArray());
        }
    }
}
