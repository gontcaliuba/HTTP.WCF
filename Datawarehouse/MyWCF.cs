using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PAD_04v1;

namespace Datawarehouse
{
    class DWSaver
    {
        // хранилище данных
        static public
        EmployeeRepository repository = new EmployeeRepository();
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyWCF" in both code and config file together.
    public class MyWCF : IMyWCF
    {
        public void addEmployeeRepository(EmployeeRepository rep)
        {
            if (rep == null) return;
            DWSaver.repository.Add(rep);

            // выводим подтверждение
            Console.WriteLine("От узла были получены следующие данные:\n");
            Console.WriteLine(rep.ToString());
        }

        public EmployeeRepository getEmployeeRepository()
        {
            return DWSaver.repository;
        }

        public EmployeeRepository filterBy()
        {
            Calculator c = new Calculator(DWSaver.repository);
            return c.filterBy();
        }

        public List<EmployeeRepository> groupBy()
        {
            Calculator c = new Calculator(DWSaver.repository);
            return c.groupBy();
        }

        public EmployeeRepository sortBy()
        {
            Calculator c = new Calculator(DWSaver.repository);
            return c.sortBy();
        }
    }
}
