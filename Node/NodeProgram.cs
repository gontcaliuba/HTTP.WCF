using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datawarehouse;
using PAD_04v1;
using System.ServiceModel;

namespace Node
{
    class NodeProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Я - узел!\n");

            Initializator ini = new Initializator(args);
            string filename = ini.txtName();

            // считываем файлы с диска
            EmployeeRepository er1 = null;
            try
            {
                er1 = new JsonWorker(filename).jsonRead();
            }
            catch
            {
                Console.WriteLine("Не удалось прочесть файл с диска!");
                Console.ReadKey();
                return;
            }

            // передаем данные серверу
            IMyWCF service = null;
            try
            {
                // подключаемся
                EndpointAddress address = new EndpointAddress(new Uri("http://localhost:8080/"));
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<IMyWCF> factory = new ChannelFactory<IMyWCF>(binding, address);
                service = factory.CreateChannel();

                // добавляем данные на сервер
                service.addEmployeeRepository(er1);

                // выводим подтверждение
                Console.WriteLine("Серверу были отправлены следующие данные от этого узла:\n");
                Console.WriteLine(er1.ToString());
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Не удалось подключиться к серверу!");
                Console.ReadKey();
                return;
            }
        }
    }
}
