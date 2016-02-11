using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Datawarehouse;
using PAD_04v1;
using System.Xml.Linq;

namespace Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Я - клиент!\n");

            // получаем данные от сервера
            IMyWCF service = null;
            try
            {
                // подключаемся
                EndpointAddress address = new EndpointAddress(new Uri("http://localhost:8080/"));
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<IMyWCF> factory = new ChannelFactory<IMyWCF>(binding, address);
                service = factory.CreateChannel();

                // запрос действия у пользователя
                Console.WriteLine("Выберите действие: 1 - filterBy, 2 - groupBy, 3 - sortBy.");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        EmployeeRepository rep1 = service.filterBy();
                        Console.WriteLine(rep1.ToString());

                        string rep1_str = XMLWorker.SerializeObject(rep1);
                        Validator val1 = new Validator(XDocument.Parse(rep1_str));
                        Console.WriteLine(val1.ToString());
                        break;

                    case '2':
                        List <EmployeeRepository> lst = service.groupBy();
                        foreach (EmployeeRepository er in lst)
                            Console.WriteLine(er.ToString());

                        EmployeeRepository rep2 = new EmployeeRepository();
                        rep2.Add(lst);
                        string rep2_str = XMLWorker.SerializeObject(rep2);
                        Validator val2 = new Validator(XDocument.Parse(rep2_str));
                        Console.WriteLine(val2.ToString());
                        break;

                    case '3':
                        EmployeeRepository rep3 = service.sortBy();
                        Console.WriteLine(rep3.ToString());

                        string rep3_str = XMLWorker.SerializeObject(rep3);
                        Validator val3 = new Validator(XDocument.Parse(rep3_str));
                        Console.WriteLine(val3.ToString());
                        break;

                    default:
                        Console.WriteLine("Неверная опция!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Не удалось подключиться к серверу!");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода!");
            Console.ReadKey();
        }
    }
}
