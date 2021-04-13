using System;
using System.IO;


namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите путь к файлу с адресами прокси серверов \n" +
                "пример : C:\\Users\\админ\\Desktop\\proxy\\1.txt ");
            string pathFileProxies = Path.Combine(AppContext.BaseDirectory, "proxy1.txt");
            Console.WriteLine("ВВедите путь к файлу в которой нужно сохранить файл с результатом проверки \n" +
                "пример : C:\\Users\\админ\\Desktop\\proxy\\2.txt");
            string pathSaveRezult = Path.Combine(AppContext.BaseDirectory, "proxy2.txt");
            Console.WriteLine("ВВедите нужное количество потоков");
            int threadCount = Convert.ToInt32(Console.ReadLine());
            new FileWorker(pathFileProxies, pathSaveRezult, threadCount);
            

        }
        
    }
}
