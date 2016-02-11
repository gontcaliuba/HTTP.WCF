using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datawarehouse;
using System.ServiceModel;

namespace Server
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Я - сервер!");

            try
            {
                ServiceHost host = new ServiceHost(typeof(MyWCF), new Uri("http://localhost:8080/"));
                host.AddServiceEndpoint(typeof(IMyWCF), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервер запущен! Нажмите любую клавишу, чтобы остановить сервер.\n");
                Console.ReadKey();
                host.Close();
                Console.WriteLine("\nСервер остановлен!");
            }
            catch
            {
                Console.WriteLine("Ошибка!!! Запустите программу (или VS) в режиме администратора.");
            }

            Console.ReadKey();
        }
    }
}
