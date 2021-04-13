using System;


namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите путь к файлу с адресами прокси серверов \n" +
                "пример : C:\\Users\\админ\\Desktop\\proxy\\1.txt ");
            string pathFileProxies = Console.ReadLine();
            Console.WriteLine("ВВедите путь к файлу в которой нужно сохранить файл с результатом проверки \n" +
                "пример : C:\\Users\\админ\\Desktop\\proxy\\2.txt");
            string pathSaveRezult = Console.ReadLine();
            Console.WriteLine("ВВедите нужное количество потоков");
            int threadCount = Convert.ToInt32(Console.ReadLine());
            new FileWorker(pathFileProxies, pathSaveRezult, threadCount);
            

        }
        
    }
}
